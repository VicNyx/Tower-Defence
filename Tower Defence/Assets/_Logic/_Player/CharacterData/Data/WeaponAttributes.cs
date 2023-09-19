using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player Logic/AttackAttributes")]
public class WeaponAttributes : ScriptableObject
{
    [Header("Damage")]
    [SerializeField] private float slashAttackDamage;
    [SerializeField] private float bluntAttackDamage;
    [SerializeField] private float pierceAttackDamage;
    [SerializeField] private float attackDamage;

    [Header("Range")]
    [SerializeField] private float attackRange;

    public float SlashAttackDamage => slashAttackDamage;
    public float BluntAttackDamage => bluntAttackDamage;
    public float PierceAttackDamage => pierceAttackDamage;
    public float AttackDamage => attackDamage;
    public float AttackRange => attackRange;
}
