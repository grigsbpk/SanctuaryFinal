using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrompt : MonoBehaviour
{

    public GameObject MenuUI;
    

    public void OpenMenu()
    {
        if(MenuUI != null)
        {
            MenuUI.SetActive(true);
        }
    }

    public void CloseMenu()
    {
        if(MenuUI != null)
        {
            MenuUI.SetActive(false);
        }
    }
}
