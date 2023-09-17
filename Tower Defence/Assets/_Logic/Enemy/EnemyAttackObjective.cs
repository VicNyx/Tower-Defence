using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackObjective : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private AI_DamageAttributes _aiDMG;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objective"))
        {
            ObjectiveHealth _objectHP = other.gameObject.GetComponent<ObjectiveHealth>();

            if (_objectHP != null)
            {
                _objectHP.Damage(_aiDMG.AI_Damage);
            }

            _enemy.Damage(1500f);
        }
    }
}
