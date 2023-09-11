using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class TowerPlaceCheck : MonoBehaviour
{

    [SerializeField] public bool towerCheck = false;
    
    GameObject tower;
    public GameObject towerSpot;

    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.FindWithTag("Tower").GetComponent<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollision(Collision collision)
    {
        if (towerCheck == false)
        {
            if (collision.gameObject.tag == "TowerSpot")
            {
                towerCheck = true;
                if (towerCheck && Input.GetButtonDown("Q"))
                {
                    float towerSpotX = towerSpot.transform.position.x;
                    float towerSpotY = towerSpot.transform.position.y;
                    float towerSpotZ = towerSpot.transform.position.z;

                    tower.transform.position = new Vector3(towerSpotX, towerSpotY, towerSpotZ);
                }
            }
            else if (collision.gameObject.tag == "Ground")
            {
                towerCheck = false;
            }
        }
    }


}
