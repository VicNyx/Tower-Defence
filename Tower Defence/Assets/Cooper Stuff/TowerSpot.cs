using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    public bool isFilled = false;
    TowerPlace place;


    // Start is called before the first frame update
    void Start()
    {
        place = GetComponent<TowerPlace>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollision(Collision collision)
    {
        if (collision.gameObject.tag == "Tower")
        {
            isFilled = true;
        }
    }
}
