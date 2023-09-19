using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{

    public int currency;
    public int startCurrency = 1000;
    GameObject TaxCurrency;

    private TextMeshProUGUI currencyTextMesh;
    TestGroundCheckCooper groundCheck;
    TowerFill fill;
    



    // Start is called before the first frame update
    void Start()
    {
        currencyTextMesh = GetComponent<TextMeshProUGUI>();
        currency = startCurrency;
        groundCheck = GetComponent<TestGroundCheckCooper>();
        fill = GetComponent<TowerFill>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrencyAdd()
    {
        currency = currency + 10;
        currencyTextMesh.text = currency.ToString();
    }

    public void CurrencyRemoveTower1()
    {
        
        
        currency = currency - 500;
        currencyTextMesh.text = currency.ToString();

    }
    public void CurrencyRemoveTower2()
    {
        currency = currency - 300;
        currencyTextMesh.text = currency.ToString();


    }
    public void CurrencyRemoveTower3()
    {
        currency = currency - 700;
        currencyTextMesh.text = currency.ToString();


    }


}
