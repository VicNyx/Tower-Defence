using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{

    //Script Done By Cooper

    public int currency;  //Cooper
    public int startCurrency = 1000; //Cooper
    GameObject TaxCurrency; //Cooper

    private TextMeshProUGUI currencyTextMesh; //Cooper
    TestGroundCheckCooper groundCheck; //Cooper
    TowerFill fill; //Cooper
    



    // Start is called before the first frame update
    void Start()  //Cooper
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

    public void CurrencyAdd() //Cooper
    {
        currency = currency + 10;
        currencyTextMesh.text = currency.ToString();
    }

    public void CurrencyRemoveTower1() //Cooper
    {
        
        
        currency = currency - 500;
        currencyTextMesh.text = currency.ToString();

    }
    public void CurrencyRemoveTower2() //Cooper
    {
        currency = currency - 300;
        currencyTextMesh.text = currency.ToString();


    }
    public void CurrencyRemoveTower3() //Cooper
    {
        currency = currency - 700;
        currencyTextMesh.text = currency.ToString();


    }


}
