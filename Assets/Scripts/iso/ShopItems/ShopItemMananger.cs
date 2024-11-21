using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemManager : MonoBehaviour
{
    public static ShopItemManager Instance; 

    public bool[] selectedItems = new bool[4]; // États de sélection des 4 objets

    private void Awake()
    {
        // Assure que ce script reste en mémoire pour la prochaine scène
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetItemState(int index, bool state)
    {
        if (index >= 0 && index < selectedItems.Length)
        {
            selectedItems[index] = state;
        }
    }

    public bool GetItemState(int index)
    {
        if (index >= 0 && index < selectedItems.Length)
        {
            return selectedItems[index];
        }
        return false;
    }
}
