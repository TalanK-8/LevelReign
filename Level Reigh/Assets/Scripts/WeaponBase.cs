using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponRarity
{
    Common,
    Rare,
    Epic,
    Legendary,
    Mythic,
    Godly,
    Ungodly
}

public abstract class WeaponBase : ScriptableObject
{
    public string weaponName;
    public float damage;
    public float cooldown;
    public WeaponRarity rarity;

    public abstract void Attack(Transform attackOrigin, LayerMask enemyLayer);
}
