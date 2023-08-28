using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{

    public float Currency;
    public float startCurrency = 1000f;
    GameObject TaxCurrency;
    public Text money;



    // Start is called before the first frame update
    void Start()
    {
        Currency = startCurrency;
        money = GameObject.Find("CurrencyText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CurrencyAdd()
    {

    }

    public void CurrencyRemoveTower1()
    {
        Currency = Currency - 500f;
        
    }


}
