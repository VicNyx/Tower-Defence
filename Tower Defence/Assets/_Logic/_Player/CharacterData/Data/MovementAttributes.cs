using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Player Logic/MovementAttributes")]
public class MovementAttributes : ScriptableObject
{
    [Header("Speed")]
    [SerializeField] private float standardSpeed;
    [SerializeField] private float fallSpeed;

    [Header("Jump")]
    [SerializeField] private int maxJumps;
    [SerializeField] private float jumpForce;

    [Header("Physics")]
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float fallMultiplier;

    //set public
    public float StandardSpeed => standardSpeed;
    public float FallSpeed => fallSpeed;
    public int MaxJumps => maxJumps;
    public float JumpForce => jumpForce;
    public float Gravity => gravity;
    public float FallMultiplier => fallMultiplier;
}
