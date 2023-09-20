using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Prefabs")]
    //naked
    [SerializeField] private GameObject slashEnemy1;
    [SerializeField] private GameObject slashEnemy2;
    //armoured
    [SerializeField] private GameObject armourEnemy1;
    [SerializeField] private GameObject armourEnemy2;
    //shielded
    [SerializeField] private GameObject shieldEnemy1;
    [SerializeField] private GameObject shieldEnemy2;

    [Header("Queue")]
    public Queue<GameObject> slashEnemy1Pool = new Queue<GameObject>();
    public Queue<GameObject> slashEnemy2Pool = new Queue<GameObject>();
    public Queue<GameObject> armourEnemy1Pool = new Queue<GameObject>();
    public Queue<GameObject> armourEnemy2Pool = new Queue<GameObject>();
    public Queue<GameObject> shieldEnemy1Pool = new Queue<GameObject>();
    public Queue<GameObject> shieldEnemy2Pool = new Queue<GameObject>();

    [Header("Queue Sizes")]
    [SerializeField] public int enemySize1 = 150;
    [SerializeField] public int enemySize2 = 150;
    [SerializeField] public int enemySize3 = 150;
    [SerializeField] public int enemySize4 = 150;
    [SerializeField] public int enemySize5 = 150;
    [SerializeField] public int enemySize6 = 159;


    private void Awake()
    {
        //get slashEnemy1
        for (int i = 0; i < enemySize1; i++)
        {
            GameObject enemy1 = Instantiate(slashEnemy1);
            slashEnemy1Pool.Enqueue(enemy1);
            enemy1.SetActive(false);
        }

        //get slashEnemy2
        for (int i = 0; i < enemySize2; i++)
        {
            GameObject enemy2 = Instantiate(slashEnemy2);
            slashEnemy2Pool.Enqueue(enemy2);
            enemy2.SetActive(false);
        }

        //get armourEnemy1
        for (int i = 0; i < enemySize3; i++)
        {
            GameObject enemy1 = Instantiate(armourEnemy1);
            armourEnemy1Pool.Enqueue(enemy1);
            enemy1.SetActive(false);
        }

        //get armourEnemy2
        for (int i = 0; i < enemySize4; i++)
        {
            GameObject enemy1 = Instantiate(armourEnemy2);
            armourEnemy2Pool.Enqueue(enemy1);
            enemy1.SetActive(false);
        }

        //get shieldEnemy1
        for (int i = 0; i < enemySize5; i++)
        {
            GameObject enemy1 = Instantiate(shieldEnemy1);
            shieldEnemy1Pool.Enqueue(enemy1);
            enemy1.SetActive(false);
        }

        //get shieldEnemy2
        for (int i = 0; i < enemySize6; i++)
        {
            GameObject enemy1 = Instantiate(shieldEnemy2);
            shieldEnemy2Pool.Enqueue(enemy1);
            enemy1.SetActive(false);
        }
    }

    #region Grab Enemies

    public GameObject GetEnemy1()
    {
        if(slashEnemy1Pool.Count > 0)
        {
            GameObject enemy1 = slashEnemy1Pool.Dequeue();
            enemy1.SetActive(true);
            return enemy1;
        }
        else
        {
            GameObject enemy1 = Instantiate(slashEnemy1);
            return enemy1;
        }
    }

    public GameObject GetEnemy2()
    {
        if (slashEnemy2Pool.Count > 0)
        {
            GameObject enemy2 = slashEnemy2Pool.Dequeue();
            enemy2.SetActive(true);
            return enemy2;
        }
        else
        {
            GameObject enemy2 = Instantiate(slashEnemy2);
            return enemy2;
        }

    }

    public GameObject GetEnemy3()
    {
        if (armourEnemy1Pool.Count > 0)
        {
            GameObject enemy2 = armourEnemy1Pool.Dequeue();
            enemy2.SetActive(true);
            return enemy2;
        }
        else
        {
            GameObject enemy2 = Instantiate(armourEnemy1);
            return enemy2;
        }
    }

    public GameObject GetEnemy4()
    {
        if (armourEnemy2Pool.Count > 0)
        {
            GameObject enemy2 = armourEnemy2Pool.Dequeue();
            enemy2.SetActive(true);
            return enemy2;
        }
        else
        {
            GameObject enemy2 = Instantiate(armourEnemy2);
            return enemy2;
        }
    }

    public GameObject GetEnemy5()
    {
        if (shieldEnemy1Pool.Count > 0)
        {
            GameObject enemy2 = shieldEnemy1Pool.Dequeue();
            enemy2.SetActive(true);
            return enemy2;
        }
        else
        {
            GameObject enemy2 = Instantiate(shieldEnemy1);
            return enemy2;
        }
    }

    public GameObject GetEnemy6()
    {
        if (shieldEnemy2Pool.Count > 0)
        {
            GameObject enemy2 = shieldEnemy2Pool.Dequeue();
            enemy2.SetActive(true);
            return enemy2;
        }
        else
        {
            GameObject enemy2 = Instantiate(shieldEnemy2);
            return enemy2;
        }
    }

    #endregion

    #region Re-Queue Enemies

    public void RequeueEnemy1(GameObject enemy1)
    {
        enemy1.SetActive(false);
        slashEnemy1Pool.Enqueue(enemy1);
    }

    public void RequeueEnemy2(GameObject enemy2)
    {
        enemy2.SetActive(false);
        slashEnemy2Pool.Enqueue(enemy2);
    }

    public void RequeueEnemy3(GameObject enemy3)
    {
        enemy3.SetActive(false);
        armourEnemy1Pool.Enqueue(enemy3);
    }

    public void RequeueEnemy4(GameObject enemy4)
    {
        enemy4.SetActive(false);
        armourEnemy2Pool.Enqueue(enemy4);
    }

    public void RequeueEnemy5(GameObject enemy5)
    {
        enemy5.SetActive(false);
        shieldEnemy1Pool.Enqueue(enemy5);
    }

    public void RequeueEnemy6(GameObject enemy6)
    {
        enemy6.SetActive(false);
        shieldEnemy2Pool.Enqueue(enemy6);
    }

    #endregion
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