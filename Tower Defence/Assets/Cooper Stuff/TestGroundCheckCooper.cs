using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TestGroundCheckCooper : MonoBehaviour
{

    [Header("TowerSpotBool")]
    public bool testTowerCheck = false;

    [Header("TowerSpot")]
    public GameObject TowerLoc;

    [Header("SphereDetectionStuff")]
    [SerializeField] private float timer;
    public float radius = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            Vector3 playerPos = transform.position;

            var towerPlaceCheck = Physics.OverlapSphere(playerPos, radius);
            
            foreach (var towerSpot in towerPlaceCheck)
            {
                if (towerSpot.tag == "TowerSpot")
                {
                    testTowerCheck = true;
                }
                else
                {
                    testTowerCheck = false;
                }
                break;
            }
            
            timer = 0;
        }
    }

    
}
