using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI", menuName = "AI Logic/AI_DamageAttributes")]
public class AI_DamageAttributes : ScriptableObject
{
    [Header("Damage")]
    [SerializeField] private float ai_Damage;

    public float AI_Damage => ai_Damage;
}
