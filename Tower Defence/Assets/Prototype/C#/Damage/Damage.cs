using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    enum DamageType
    {
        Blunt,
        Slash,
        Pierce
    }

    [SerializeField] DamageType type;
}
