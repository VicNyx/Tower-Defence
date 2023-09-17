using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private WeaponAttributes _weapon;

    [Header("Swapping Weapons")]
    [SerializeField] private bool canChange;
    [SerializeField] private float interactDistance;

    public GameObject[] weapons;

    private int currentWeaponIndex;
    private Animator anim;

    private void Awake()
    {
        anim = weapons[currentWeaponIndex].GetComponent<Animator>();
        SwitchWeapon(0);
        canChange = true;
    }

    private void Update()
    {
        if(canChange && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithBox();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAttack();
        }
    }

    private void InteractWithBox()
    {
        GameObject[] weaponBoxes = GameObject.FindGameObjectsWithTag("WeaponBox");

        foreach (GameObject weaponBox in weaponBoxes)
        {
            float disToBox = Vector3.Distance(transform.position, weaponBox.transform.position);

            if(disToBox <= interactDistance)
            {
                int nextWeaponIndex = (currentWeaponIndex + 1) % weapons.Length; //inteli suggested, % weapons.Length.
                SwitchWeapon(nextWeaponIndex);

                //exit out of loop after interactin with weaponBox
                break;
            }
        }
    }

    public void SwitchWeapon(int weaponIndex)
    {
        //disable current weapon
        weapons[currentWeaponIndex].SetActive(false);

        //update index
        currentWeaponIndex = weaponIndex;

        //enable new weapon
        weapons[currentWeaponIndex].SetActive(true);

        //update anim reference to new weapon
        anim = weapons[currentWeaponIndex].GetComponent<Animator>();

        canChange = false;
        Invoke(nameof(EnableSwitching), 0.5f);
    }

    private void EnableSwitching()
    {
        canChange = true;
    }

    public void DeactivateAllWeapons()
    {
        foreach(GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }
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