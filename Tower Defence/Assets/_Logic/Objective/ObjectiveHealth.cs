using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveHealth : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private ObjectiveAttributes _object;

    //trackable for UI
    public float currentHealth;

    private void Awake()
    {
        currentHealth = _object.MaxHealth;
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
