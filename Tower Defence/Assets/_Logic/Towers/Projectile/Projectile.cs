using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public int damage = 50;

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
            e.Damage(damage);
        }
        
        Destroy(gameObject);
    }
}
