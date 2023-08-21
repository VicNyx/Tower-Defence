using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggedSpawner : MonoBehaviour
{

    public GameObject Tower;
    public float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer <= 15 )
        {
            Instantiate(Tower, transform.position, Quaternion.identity);
            Debug.Log("Work");
        }
        
    }
}
