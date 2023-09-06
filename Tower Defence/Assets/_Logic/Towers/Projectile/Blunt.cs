using UnityEngine;

public class Blunt : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public int damage = 50;

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
            if (e.armourType == Enemy.ArmourType.Shielded)
            {
                e.Damage(damage * 1.5f);
            }
            else if (e.armourType == Enemy.ArmourType.Armoured)
            {
                e.Damage(damage);
            }
            else if (e.armourType == Enemy.ArmourType.Unarmoured)
            {
                e.Damage(damage * 0.5f);
            }
        }

        Destroy(gameObject);
    }
}
