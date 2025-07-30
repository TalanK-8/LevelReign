using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Fist")]
public class FistWeapon : WeaponBase
{
    public float attackRange = 1.5f;

    public override void Attack(Transform attackOrigin, LayerMask enemyLayer)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackOrigin.position, attackRange, enemyLayer);
        foreach (var hit in hits)
        {
            Debug.Log("Hit " + hit.name);
            // You can reduce enemy health here if you have a damage script
        }
    }
}
