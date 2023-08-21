using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerMover : MonoBehaviour
{
    public GameObject tower1prefab;
    public float mouseSense = 100f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;
        tower1prefab.transform.position = new Vector3(mouseX, mouseY);

    }

}
