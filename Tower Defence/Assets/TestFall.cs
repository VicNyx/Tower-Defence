using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;

public class TestFall : MonoBehaviour
{
    public bool Detect;
    public float fallTimer;
    public float testRad = 10;
    public float halfRadius = 5;
    public LayerMask c_layerMask;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fallTimer += Time.deltaTime;
        if (fallTimer > 0.5)
        {
            Vector3 testPos = transform.position;

            Vector3 halfRad = transform.localScale * 3 ;

            var FallerChecker = Physics.OverlapBox(testPos, halfRad, Quaternion.identity, c_layerMask);

            foreach (var faller in FallerChecker)
            {
                if (faller.tag == "Test")
                {
                    Detect = true;
                }
                else
                {
                    Detect = false;
                }
                break;
            }
            fallTimer = 0;
        }
    }
}
