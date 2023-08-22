using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E : MonoBehaviour, IDamagable
{
    [field: SerializeField] public float MaxHealth { get; set; }
    public float CurrentHealth { get; set; }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void Hurt()
    {

    }

    public void BaseDamage(float damage)
    {
        CurrentHealth -= damage;

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void WeaknessDamage(float damage)
    {
        CurrentHealth -= damage * 1.5f;

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void ResistDamage(float damage)
    {
        CurrentHealth -= damage * 0.5f;

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
