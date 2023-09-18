using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackPlayer : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerHealthController _health = other.gameObject.GetComponent<PlayerHealthController>();

            if (_health != null)
            {
                _health.Damage(_aiDMG.AI_Damage);
            }

            _enemy.Damage(1500f);
        }
    }
}
