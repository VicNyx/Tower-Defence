using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggedSpawner : MonoBehaviour
{

    public GameObject Tower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(Tower, transform.position, Quaternion.identity);
    }
}
