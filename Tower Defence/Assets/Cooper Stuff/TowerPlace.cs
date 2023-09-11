using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{

    TestGroundCheckCooper towerGroundChecker;

    [Header("Towers")]
    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;

    [Header("TowerSpotLocation")]
    public GameObject towerSpot;
    public GameObject towerPlaceSpot;


    [Header("Player things")]
    public float playerRad = 5;

    TowerSpot spot;
    

    // Start is called before the first frame update
    void Start()
    {
        towerGroundChecker = GetComponent<TestGroundCheckCooper>();
        spot = GetComponent<TowerSpot>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TowerPlacementTower1()
    {

        Vector3 towerSpotLoc = towerSpot.transform.position;
        Vector3 towerPlaceLoc = towerPlaceSpot.transform.position;


        if (towerGroundChecker.testTowerCheck)
        {
            Vector3 PlayerPos = transform.position;

            var TowerSpots = Physics.OverlapSphere(PlayerPos, playerRad);

            foreach (var TowerSpot in TowerSpots)
            {
                if (TowerSpot.tag == "TowerSpot")
                {
                    Instantiate(tower1, TowerSpot.transform.position, Quaternion.identity);



                }
            }
            
        }
    }
    public void TowerPlacementTower2()
    {

        Vector3 towerSpotLoc = towerSpot.transform.position;
        Vector3 towerPlaceLoc = towerPlaceSpot.transform.position;


        if (towerGroundChecker.testTowerCheck && spot.isFilled == false)
        {
            Vector3 PlayerPos = transform.position;

            var TowerSpots = Physics.OverlapSphere(PlayerPos, playerRad);

            foreach (var TowerSpot in TowerSpots)
            {
                if (TowerSpot.tag == "TowerSpot")
                {
                    Instantiate(tower2, TowerSpot.transform.position, Quaternion.identity);
                    spot.isFilled = true;
                }
            }
        }
    }
    public void TowerPlacementTower3()
    {

        Vector3 towerSpotLoc = towerSpot.transform.position;
        Vector3 towerPlaceLoc = towerPlaceSpot.transform.position;

        if (towerGroundChecker.testTowerCheck && spot.isFilled == false)
        {
            Vector3 PlayerPos = transform.position;

            var TowerSpots = Physics.OverlapSphere(PlayerPos, playerRad);

            foreach (var TowerSpot in TowerSpots)
            {
                if (TowerSpot.tag == "TowerSpot")
                {
                    Instantiate(tower3, TowerSpot.transform.position, Quaternion.identity);
                    spot.isFilled = true;
                }
            }
        }
    }
}
