using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGroundCheckCooper : MonoBehaviour
{
    public bool testTowerCheck = false;
    public GameObject TowerLoc;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollision(Collision collision)
    {
        if (testTowerCheck == false)
        {
            if (collision.gameObject.tag == "TestGround")
            {
                testTowerCheck = true;

            }
            else if (collision.gameObject.tag == "Ground")
            {
                testTowerCheck = false;
            }
        } 
    }
}
