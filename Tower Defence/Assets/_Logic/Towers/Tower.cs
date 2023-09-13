using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    enum DamageType
    {
        Slash,
        Blunt,
        Pierce,
        None
    }

    [SerializeField] DamageType damageType;

    private Transform target;

    public float range = 15f;
    public float timeBetweenShots = 1f;
    private float timer;

    public GameObject projectilePrefab;
    public Transform firepoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);
        // Easier on resources using InvokeRepeating rather than putting it in update
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy1");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else target = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        if (timer > timeBetweenShots)
        {
            timer = 0f;

            Fire();
        }

        timer += Time.deltaTime;
    }

    void Fire()
    {
        GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, firepoint.position, firepoint.rotation);
        Projectile projectile = projectileGO.GetComponent<Projectile>();

        if (damageType == DamageType.Slash) projectile.SetDamageType(Projectile.DamageType.Slash);
        else if (damageType == DamageType.Pierce) projectile.SetDamageType(Projectile.DamageType.Pierce);
        else if (damageType == DamageType.Blunt) projectile.SetDamageType(Projectile.DamageType.Blunt);
        else projectile.SetDamageType(Projectile.DamageType.None);

        if (projectile != null) projectile.Seek(target);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
