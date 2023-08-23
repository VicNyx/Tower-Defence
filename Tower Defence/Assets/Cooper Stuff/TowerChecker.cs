using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChecker : MonoBehaviour
{

    [SerializeField] private bool towerOnSpot = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (towerOnSpot == false)
        {
            if (collision.gameObject.tag == "Tower")
            {
                towerOnSpot = true;
            }
        }
    }

}
