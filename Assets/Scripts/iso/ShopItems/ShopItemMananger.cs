using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopItemManager : MonoBehaviour
{
    public static ShopItemManager Instance;
    public bool[] selectedItems = new bool[4]; // États de sélection des 4 objets

    private bool firstLoadDone = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (firstLoadDone)
        {
            // On a déjà passé la première transition de scène.
            // Maintenant, on se trouve dans une scène suivante (peut-être un retour au shop ou un autre niveau).
            // On détruit donc le manager et on se désabonne.
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
        }
        else
        {
            // C'est la première fois qu'on change de scène (du shop vers le niveau).
            // On marque que la transition est faite, mais on garde l'objet pour que les items soient effectifs dans cette scène.
            firstLoadDone = true;
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

    public void ResetSelectedItems()
    {
        for (int i = 0; i < selectedItems.Length; i++)
        {
            selectedItems[i] = false;
        }
        Debug.Log("ShopItemManager: Les états des items ont été réinitialisés.");
    }
}
