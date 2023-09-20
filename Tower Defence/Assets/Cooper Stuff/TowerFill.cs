using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFill : MonoBehaviour
{
    //This Script was Written by Cooper


    public bool towerFill = false;
    public float timer;
    public float radius = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() //Written by Cooper
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
                    towerFill = true;
                }
                else
                {
                    towerFill = false;
                }
                break;
            }

            timer = 0;
        }
    }

    public void OnCollisionStay(Collision collision) //Written by Cooper
    {
        if (collision.gameObject.tag == "TowerSpot")
        {
            towerFill = true;
        }
    }
}
