using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    private PlayerHealthController pcHealth;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        pcHealth = FindObjectOfType<PlayerHealthController>();
    }

    public void RespawnPlayer()
    {
        pcHealth.Respawn();
    }
}
