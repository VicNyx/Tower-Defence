using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private WeaponAttributes _weapon;

    public GameObject[] weapons;

    private int currentWeaponIndex;
    private Animator anim;

    private void Awake()
    {
        anim = weapons[currentWeaponIndex].GetComponent<Animator>();
        SwitchWeapon(0);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            SwitchWeapon(0);
        }
        else if(Input.GetKeyDown(KeyCode.O))
        {
            SwitchWeapon(1);
        }
        else if(Input.GetKeyDown(KeyCode.P))
        {
            SwitchWeapon(2);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAttack();
        }
    }

    private void SwitchWeapon(int weaponIndex)
    {
        //disable current weapon
        weapons[currentWeaponIndex].SetActive(false);

        //update index
        currentWeaponIndex = weaponIndex;

        //enable new weapon
        weapons[currentWeaponIndex].SetActive(true);

        //update references to new weapon
        anim = weapons[currentWeaponIndex].GetComponent<Animator>();
    }

    private void PlayerAttack()
    {

        GameObject currentWeapon = weapons[currentWeaponIndex];

        if(currentWeapon.CompareTag("Slash"))
        {
            SlashAttack();
        }
        else if(currentWeapon.CompareTag("Blunt"))
        {
            BluntAttack();
        }
        else if(currentWeapon.CompareTag("Pierce"))
        {
            PierceAttack();
        }
    }

    private void SlashAttack()
    {
        anim.SetTrigger("SlashAttack");

        RaycastHit[] hits;

        hits = Physics.RaycastAll(transform.position, transform.forward, _weapon.AttackRange);

        foreach(RaycastHit hit in hits)
        {
            if(hit.collider.CompareTag("Enemy"))
            {
                Enemy _enemy = hit.collider.GetComponent<Enemy>();
                if(_enemy != null)
                {
                    _enemy.Damage(_weapon.SlashAttackDamage);
                }
            }
        }
    }

    private void BluntAttack()
    {
        anim.SetTrigger("BluntAttack");

        RaycastHit[] hits;

        hits = Physics.RaycastAll(transform.position, transform.forward, _weapon.AttackRange);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy _enemy = hit.collider.GetComponent<Enemy>();
                if (_enemy != null)
                {
                    _enemy.Damage(_weapon.BluntAttackDamage);
                }
            }
        }
    }

    private void PierceAttack()
    {
        anim.SetTrigger("PierceAttack");

        RaycastHit[] hits;

        hits = Physics.RaycastAll(transform.position, transform.forward, _weapon.AttackRange);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Enemy _enemy = hit.collider.GetComponent<Enemy>();
                if (_enemy != null)
                {
                    _enemy.Damage(_weapon.PierceAttackDamage);
                }
            }
        }
    }
}

/* @Tysonn J. Smith 2023
 * 
 * used raycasts to detect enemies and calls funtion on enemy to damage enemy
 * 
 * I hate the unity animator.... :)
 * 
 */