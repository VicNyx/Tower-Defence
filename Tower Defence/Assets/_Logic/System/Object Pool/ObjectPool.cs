using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject enemy1Prefab;
    [SerializeField] private GameObject enemy2Prefab;

    [Header("Queue")]
    public Queue<GameObject> enemy1Pool = new Queue<GameObject>();
    public Queue<GameObject> enemy2Pool = new Queue<GameObject>();

    [Header("Queue Sizes")]
    [SerializeField] public int enemy1Size = 160;
    [SerializeField] public int enemy2Size = 160;

    private void Start()
    {
        //get enemy1Prefab
        for (int i = 0; i < enemy1Size; i++)
        {
            GameObject enemy1 = Instantiate(enemy1Prefab);
            enemy1Pool.Enqueue(enemy1);
            enemy1.SetActive(false);
        }

        //get enemy2Prefab
        for (int i = 0;i < enemy2Size; i++)
        {
            GameObject enemy2 = Instantiate(enemy2Prefab);
            enemy2Pool.Enqueue(enemy2);
            enemy2.SetActive(false);
        }
    }

    public GameObject GetEnemy1()
    {
        if(enemy1Pool.Count > 0)
        {
            GameObject enemy1 = enemy1Pool.Dequeue();
            enemy1.SetActive(true);
            return enemy1;
        }
        else
        {
            GameObject enemy1 = Instantiate(enemy1Prefab);
            return enemy1;
        }
    }

    public GameObject GetEnemy2()
    {
        if (enemy2Pool.Count > 0)
        {
            GameObject enemy2 = enemy2Pool.Dequeue();
            enemy2.SetActive(true);
            return enemy2;
        }
        else
        {
            GameObject enemy2 = Instantiate(enemy2Prefab);
            return enemy2;
        }
    }

    public void ReturnEnemy1(GameObject enemy1)
    {
        enemy1Pool.Enqueue((enemy1));
        enemy1.SetActive(false);
    }

    public void ReturnEnemy2(GameObject enemy2)
    {
        enemy2Pool.Enqueue((enemy2));
        enemy2.SetActive(false);
    }
}

/* @Tysonn J. Smith 2023 
 * 
 * using this tutorial to use queues instead of lists for my object pools 
 * @Jeremy Wolf
 * https://onewheelstudio.com/blog/2020/7/15/object-pooling
 * 
 * went with the Simple Object Pooling solution, thinking we shouldn't need it for a simple project.
 * 
 */