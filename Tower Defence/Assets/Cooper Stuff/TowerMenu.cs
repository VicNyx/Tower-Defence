using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMenu : MonoBehaviour
{

    public static bool menuOpen = false;
    public GameObject TowerPurchaseUI;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (menuOpen)
            {
                ClosetheMenu();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                OpenTheMenu();
                Cursor.lockState= CursorLockMode.None;
            }
        }
    }


    void ClosetheMenu()
    {
        TowerPurchaseUI.SetActive(false);
        Time.timeScale = 1;
        menuOpen = false;
    }

    void OpenTheMenu()
    {
        TowerPurchaseUI.SetActive(true);
        Time.timeScale = 1;
        menuOpen=true;
    }

    

}
