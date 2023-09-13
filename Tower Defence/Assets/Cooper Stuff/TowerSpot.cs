using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    public bool isFilled = false;
    TowerPlace place;
    public float timer;
    public float towerRad = 5;


    // Start is called before the first frame update
    void Start()
    {
        place = GetComponent<TowerPlace>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            Vector3 playerPos = transform.position;

            var towerOnSpotCheck = Physics.OverlapSphere(playerPos, towerRad);

            foreach (var towers in towerOnSpotCheck)
            {
                if (towers.tag == "Tower")
                {
                    isFilled = true;
                }
                else
                {
                    isFilled = false;
                }
                break;
            }

            timer = 0;
        }
    }

    public void OnCollision(Collision collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            isFilled = true;
        }
    }
}
