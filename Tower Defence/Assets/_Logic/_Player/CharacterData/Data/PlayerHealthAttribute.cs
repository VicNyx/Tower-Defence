using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player Logic/PlayerHealthAttribute")]
public class PlayerHealthAttribute : ScriptableObject
{
    [Header("Health")]
    [SerializeField] private float maxHealth;

    public float MaxHealth => maxHealth;
}
