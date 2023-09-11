using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChecker : MonoBehaviour
{
    [Header("Tower Bools")]
    public bool towerOnSpot = false;
    public bool towerOnTheSpot = false;

    [Header("Update Timer")]
    [SerializeField] private float timer;

    [Header("Player Details")]
    public float playerTowerRadius = 10;

    [Header("Tower Objects")]
    public GameObject towerSpotLoc;

    
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
            Vector3 PlayerPos = transform.position;

            var TowerSpots = Physics.OverlapSphere(PlayerPos, playerTowerRadius);

            foreach (var TowerSpot in TowerSpots)
            {
                if (TowerSpot.tag == "TowerSpot")
                {
                    Vector3 TowerSpotPos = towerSpotLoc.transform.position;

                    var Towers = Physics.OverlapSphere(PlayerPos, playerTowerRadius);

                    foreach (var Tower in Towers)
                    {
                        if (Tower.tag == "Tower")
                        {
                            towerOnSpot = true;
                        }
                        break; 
                    }
                }
                break;
            }
            timer = 0;
        }
    }

    



}
