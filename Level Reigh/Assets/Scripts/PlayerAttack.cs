using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public WeaponBase equippedWeapon;
    public Transform attackPoint;
    public LayerMask enemyLayer;

    private float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
       if (Time.time >= nextAttackTime)
       {
        equippedWeapon.Attack(attackPoint);
        nextAttackTime = Time.time + equippedWeapon.cooldown;
       } 
    }
}
