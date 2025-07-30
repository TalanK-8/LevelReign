using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Fist")]
public class FistWeapon : WeaponBase
{
    public float attackRange = 1.5f;
    public LayerMask enemyLayer;

    public override void Attack(Transform attackOrigin)
    {
        Collider[] hits = Physics.OverlapSphere(attackOrigin.position, attackRange, enemyLayer);

        foreach (var hit in hits)
        {
           EnemyHealth enemy = hit.GetComponent<EnemyHealth>();
           if (enemy != null)
           {
            enemy.TakeDamage(damage);
           }
        }
    }
}
