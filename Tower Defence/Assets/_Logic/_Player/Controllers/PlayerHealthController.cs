using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerHealthAttribute _playerHP;
    private PlayerWeaponController _weaponController;

    [Header("Transforms")]
    [SerializeField] private Transform respawnPoint;

    [Header("Respawn Timer")]
    [SerializeField] private Text respawnerTimerText;
    public int respawnTimer;
    private int respawnCountdown;

    public bool isPlayerAlive;

    public float currentHealth;
    public Text currentHealthText;


    private void Awake()
    {
        currentHealth = _playerHP.MaxHealth;
        isPlayerAlive = true;
        respawnerTimerText.gameObject.SetActive(false);

        _weaponController = FindObjectOfType<PlayerWeaponController>();
    }

    public void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    private void Update()
    {
        currentHealthText.text = currentHealth.ToString();
    }

    private void Die()
    {
        isPlayerAlive = false;
        gameObject.SetActive(false);

        respawnerTimerText.gameObject.SetActive(true);
        currentHealthText.gameObject.SetActive(false);
        respawnCountdown = respawnTimer;

        //_weaponController.DeactivateAllWeapons();

        InvokeRepeating(nameof(UpdateRespawnTimer), 0f, 1f);
        Invoke(nameof(Respawn), respawnTimer);
    }

    private void UpdateRespawnTimer()
    {
        respawnerTimerText.text = (respawnCountdown).ToString();
        respawnCountdown -= 1;

        if(respawnCountdown <= 0)
        {
            CancelInvoke(nameof(UpdateRespawnTimer));
            respawnerTimerText.gameObject.SetActive(false);
        }
    }

    public void Respawn()
    {
        currentHealth = _playerHP.MaxHealth;
        gameObject.transform.position = respawnPoint.transform.position;
        isPlayerAlive = true;

        _weaponController.SwitchWeapon(0);

        currentHealthText.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }
}

/* @Tysonn J. Smith 2023
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */