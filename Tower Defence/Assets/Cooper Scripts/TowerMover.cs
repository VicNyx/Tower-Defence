using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerMover : MonoBehaviour
{
    public float mouseSense = 100f;
    Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        planeCollider = GameObject.Find("Plane").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        transform.position = cam.ScreenToWorldPoint(new Vector3(mouseX, mouseY, 1));
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planeCollider)
            {
                transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime);
            }
        }

    }

}
