using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    void BaseDamage(float damage);
    void WeaknessDamage(float damage);
    void ResistDamage(float damage);

    void Die();

    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }
}
