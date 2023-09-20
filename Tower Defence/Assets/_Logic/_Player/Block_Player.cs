using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Player : MonoBehaviour
{
    private string tagToBlock = "Player";

    private void Awake()
    {
        int blockingLayer = LayerMask.NameToLayer("BlockingLayer");

        Physics.IgnoreLayerCollision(gameObject.layer, blockingLayer, tagToBlock == "Player");
    }
}
