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

    // Should turn this into a constructor
    public void Seek(Transform target)
    {
        this.target = target;
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
            Damage(target);
            return;
        }

        transform.Translate(dir.normalized * distancePerFrame, Space.World);
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
}
