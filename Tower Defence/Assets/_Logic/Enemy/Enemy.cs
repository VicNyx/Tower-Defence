using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum ArmourType
    {
        Armoured,
        Unarmoured,
        Shielded
    }

    public ArmourType armourType;

    public float maxHealth = 100f;
    private float currentHealth;

    CurrencyManager currencyManager; //Cooper

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currencyManager = GetComponent<CurrencyManager>(); //Cooper
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        currencyManager.CurrencyAdd(); //Cooper
    }
}
