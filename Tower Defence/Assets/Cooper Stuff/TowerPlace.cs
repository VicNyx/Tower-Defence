using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{

    //This Script was written by Cooper



    TestGroundCheckCooper towerGroundChecker; //This and Below was Written by Cooper

    [Header("Towers")]
    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;

    [Header("TowerSpotLocation")]
    public GameObject towerSpot;
    


    [Header("Player things")]
    public float playerRad = 5;

    TowerSpot spot;
    TowerFill fill;
    CurrencyManager currencyMan;

    [Header("Currency Things")]
    public int currency;
    public int startCurrency = 1000;
    public TextMeshProUGUI currencyTextMesh;

    Enemy eN;


    // Start is called before the first frame update
    void Start() //written by Cooper
    {
        currency = startCurrency;

        towerGroundChecker = GetComponent<TestGroundCheckCooper>();
        eN = GetComponent<Enemy>();
        spot = GetComponent<TowerSpot>();
        fill = GetComponent<TowerFill>();
        currencyMan = GetComponent<CurrencyManager>();
        
    }

    // Update is called once per frame
    void Update() //Written by Cooper
    {
        currencyTextMesh.text = currency.ToString();
        

    }


    public void TowerPlacementTower1() //Written by Cooper
    {

        Vector3 towerSpotLoc = towerSpot.transform.position;


        if (towerGroundChecker.testTowerCheck)
        {
            Vector3 PlayerPos = transform.position;

            var TowerSpots = Physics.OverlapSphere(PlayerPos, playerRad);

            foreach (var TowerSpot in TowerSpots)
            {
                if (TowerSpot.tag == "TowerSpot" && currency >= 500)
                {
                    
                    Instantiate(tower1, TowerSpot.transform.position, Quaternion.identity);
                    currency = currency - 500;
                    currencyTextMesh.text = currency.ToString();

                }
            }
            
        }
    }
    public void TowerPlacementTower2() //Written by Cooper
    {

        Vector3 towerSpotLoc = towerSpot.transform.position;
        


        if (towerGroundChecker.testTowerCheck)
        {
            Vector3 PlayerPos = transform.position;

            var TowerSpots = Physics.OverlapSphere(PlayerPos, playerRad);

            foreach (var TowerSpot in TowerSpots)
            {
                if (TowerSpot.tag == "TowerSpot")
                {
                    Instantiate(tower2, TowerSpot.transform.position, Quaternion.identity);
                    
                }
            }
        }
    }
    public void TowerPlacementTower3() //Written by Cooper
    {

        Vector3 towerSpotLoc = towerSpot.transform.position;
        

        if (towerGroundChecker.testTowerCheck)
        {
            Vector3 PlayerPos = transform.position;

            var TowerSpots = Physics.OverlapSphere(PlayerPos, playerRad);

            foreach (var TowerSpot in TowerSpots)
            {
                if (TowerSpot.tag == "TowerSpot")
                {
                    Instantiate(tower3, TowerSpot.transform.position, Quaternion.identity);
                    
                }
            }
        }
    }
}
