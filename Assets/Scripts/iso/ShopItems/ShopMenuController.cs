using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenuController : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject menuFood;
    private bool isNearChest = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isNearChest)
        {
            bool isMenuActive = menuPanel.activeSelf;

            menuPanel.SetActive(!isMenuActive);
            menuFood.SetActive(isMenuActive);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si l'objet avec lequel on entre en collision est un coffre
        if (other.CompareTag("Coffre"))
        {
            isNearChest = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Vérifie si l'objet avec lequel on quitte la collision est un coffre
        if (other.CompareTag("Coffre"))
        {
            isNearChest = false;
        }
    }
}
