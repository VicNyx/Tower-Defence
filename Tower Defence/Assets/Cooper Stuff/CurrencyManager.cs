using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{

    public float Currency;
    public float startCurrency = 1000f;
    GameObject TaxCurrency;
    

    public TMP_Text currencyText;



    // Start is called before the first frame update
    void Start()
    {
        Currency = startCurrency;
        currencyText = GetComponent<TMP_Text>();
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
        Currency.ToString((System.IFormatProvider)currencyText);
        
    }


}
