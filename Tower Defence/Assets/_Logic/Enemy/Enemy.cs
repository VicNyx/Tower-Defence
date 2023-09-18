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
    public float currentHealth;
    CurrencyManager currencyMan;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currencyMan = GetComponent<CurrencyManager>();
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
        currencyMan.currency = currencyMan.currency + 10;
        currencyMan.currencyTextMesh.text = currencyMan.currency.ToString();
    }
}
