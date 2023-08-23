using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    void Damage(float damageAmount);
    
    void Die();

    float maxHealth { get; set; }
    float currentHealth { get; set; }
}
