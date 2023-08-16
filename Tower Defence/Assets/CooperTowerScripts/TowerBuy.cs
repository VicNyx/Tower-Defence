using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuy : MonoBehaviour
{

    public Button tower1Button;
    public GameObject tower1Prefab;

    public Button tower2Button;
    public GameObject tower2Prefab;

    public Button tower3Button;
    public GameObject tower3Prefab;


    public void SpawnSwordTower()
    {
        Instantiate(tower1Prefab, transform.position, Quaternion.identity);
    }

    public void SpawnSpearTower ()
    {
        Instantiate(tower2Prefab, transform.position, Quaternion.identity);
    }

    public void SpawnClubTower()
    {
        Instantiate(tower3Prefab, transform.position, Quaternion.identity);
    }
}
