using UnityEngine;

public class Projectile : MonoBehaviour
{
    public enum DamageType
    {
        Slash,
        Blunt,
        Pierce,
        None
    }

    public DamageType damageType;
    private Transform target;

    public float speed = 70f;
    public int damage = 50;
    public float areaOfAffect = 0f;
    // Need to do testing on what would be a good aoe

    // Should turn this into a constructor
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distancePerFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distancePerFrame)
        {
            Explode();
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
    }

    void Explode()
    {
        Collider [] colliders = Physics.OverlapSphere(transform.position, areaOfAffect);
        
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            float weakness = Weakness(e);
            e.Damage(damage * weakness);
        }
        
        Destroy(gameObject);
    }

    public void SetDamageType(DamageType damageType)
    {
        this.damageType = damageType;
    }

    float Weakness(Enemy e)
    {
        float weaknessMultiplier = 1f;

        if (e.armourType == Enemy.ArmourType.Unarmoured)
        {
            if (damageType == DamageType.Blunt) weaknessMultiplier = 0.5f;
            else if (damageType == DamageType.Pierce) weaknessMultiplier = 1f;
            else if (damageType == DamageType.Slash) weaknessMultiplier = 1.5f;
        }
        else if (e.armourType == Enemy.ArmourType.Armoured)
        {
            if (damageType == DamageType.Blunt) weaknessMultiplier = 1f;
            else if (damageType == DamageType.Pierce) weaknessMultiplier = 1.5f;
            else if (damageType == DamageType.Slash) weaknessMultiplier = 0.5f;
        }
        else if (e.armourType == Enemy.ArmourType.Shielded)
        {
            if (damageType == DamageType.Blunt) weaknessMultiplier = 1.5f;
            else if (damageType == DamageType.Pierce) weaknessMultiplier = 0.5f;
            else if (damageType == DamageType.Slash) weaknessMultiplier = 1f;
        }

        return (float)weaknessMultiplier;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, areaOfAffect);
    }
    // Kaeden's Notes - Attach this script to a projectile prefab. Also change aoe range.
}
