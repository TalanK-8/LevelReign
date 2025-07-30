using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Fist")]
public class FistWeapon : WeaponBase
{
    public LayerMask enemyLayer;

    public override void Attack(Transform attackOrigin)
    {
        Debug.Log("FistWeapon Attack called!");

        Collider[] hits = Physics.OverlapSphere(attackOrigin.position, attackRange, enemyLayer);

        foreach (var hit in hits)
        {
            Debug.Log("Hit something: " + hit.name);
            EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
