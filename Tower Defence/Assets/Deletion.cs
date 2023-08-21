using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Deletion : MonoBehaviour
{
    private void Update()
    {
        void OnCollisionEnter(Collision collision) 
        {
            if (tag == "Deleter")
            {
                Destroy(gameObject);
            }
        }
    }


    
}
