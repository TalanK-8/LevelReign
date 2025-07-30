using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform attackPoint;
    public PlayerAttack playerAttack;
    
    private Vector3 targetPosition;
    private bool isMoving = false;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        UpdateAimAndAttackPoint();

    }

    void HandleMovement()
    {
        if (Input.GetMouseButton(0))
       {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            targetPosition = hit.point;
            isMoving = true;
        }
       } 

       if (isMoving)
       {
        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0f;

        transform.position += direction * moveSpeed * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            isMoving = false;
        }
       }
    }

    void UpdateAimAndAttackPoint()
    {
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float hitDistance))
        {
            Vector3 mouseWorldPosition = ray.GetPoint(hitDistance);
            Vector3 direction = (mouseWorldPosition - transform.position).normalized;

            Vector3 lookDirection = new Vector3(direction.x, 0f, direction.z); // zero out y to keep player upright
            if (lookDirection.sqrMagnitude > 0.001f) // check to avoid zero vector
            {
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }

            if (attackPoint != null && playerAttack != null && playerAttack.equippedWeapon != null)
            {
                float offset = playerAttack.equippedWeapon.attackRange * 0.75f;
                attackPoint.position = transform.position + direction * offset;
            }
        }
    }
}
