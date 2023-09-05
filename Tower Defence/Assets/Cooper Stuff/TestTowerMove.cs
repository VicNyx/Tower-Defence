using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTowerMove : MonoBehaviour
{
    public float mouseSense = 100f;
    Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;
    GameObject player;
    TowerPlaceCheck towerCheck;

    GameObject tower;
    GameObject towerSpot;
    Collider playerCol;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.Find("Plane").GetComponent<Collider>();
        player = GameObject.FindWithTag("Player").GetComponent<Collider>().gameObject;
        towerCheck = GetComponent<TowerPlaceCheck>();
        tower = GameObject.FindWithTag("Tower").GetComponent<GameObject>();
        towerSpot = GameObject.FindWithTag("TowerSpot").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        float playerX = player.transform.position.x;
        float playerY = player.transform.position.y;
        float playerZ = player.transform.position.z;

        transform.position = cam.ScreenToWorldPoint(new Vector3(playerX, playerY, playerZ));
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planeCollider)
            {
                transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime);
            }
            else if (Input.GetButtonDown("Q") && towerCheck.towerCheck)
            {
                float towerSpotX = towerSpot.transform.position.x;
                float towerSpotY = towerSpot.transform.position.y;
                float towerSpotZ = towerSpot.transform.position.z;

                tower.transform.position = new Vector3(towerSpotX, towerSpotY, towerSpotZ);
            }
        }

        Vector3 detect = new Vector3(playerZ, playerX, playerY);
        Physics.OverlapSphere(detect, 5);


    }
}
