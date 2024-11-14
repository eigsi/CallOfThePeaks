using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuController : MonoBehaviour
{
    public GameObject menuPanel; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }
    }
}
