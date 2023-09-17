using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objective", menuName = "Objective Logic/ObjectiveAttributes")]
public class ObjectiveAttributes : ScriptableObject
{
    [Header("Health")]
    [SerializeField] private float maxHealth;

    public float MaxHealth => maxHealth;
}
