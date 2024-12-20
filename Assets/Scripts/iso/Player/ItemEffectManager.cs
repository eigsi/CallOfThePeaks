using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectManager : MonoBehaviour
{
    public GameObject player;           // Référence au joueur
    public GameObject LanterneToDisable;
    public GameObject GrappinToDisable;
    public GameObject CramponToDisable;

    void Start()
    {
        Debug.Log("ItemEffectManager: Initialisation de l'effet des items.");
        // Vérifie que le ShopItemManager existe
        if (ShopItemManager.Instance != null)
        {
            Debug.Log("ShopItemManager trouvé. Vérification des états des items...");


            // Index 0 : Si l'item n'est PAS sélectionné, enlever un script du joueur
            if (!ShopItemManager.Instance.GetItemState(0))
            {
                Debug.Log("Item 0 n'est pas sélectionné. Suppression du script Grapple et désactivation de GrappinToDisable.");
                // Remplace 'ScriptToRemove' par le nom du script que tu veux enlever
                Grapple script = player.GetComponent<Grapple>();
                if (script != null)
                {
                    Debug.Log("Script 'Grapple' trouvé et détruit.");
                    Destroy(script);
                }
                else
                {
                    Debug.LogWarning("Le script 'ScriptToRemove' n'a pas été trouvé sur le joueur.");
                }

                if (GrappinToDisable != null)
                {
                    Debug.Log("GrappinToDisable trouvé et désactivé.");
                    GrappinToDisable.SetActive(false);
                }
                else
                {
                    Debug.LogWarning("Le GameObject à désactiver n'est pas assigné.");
                }
            }

            // Index 1 : Désactiver un GameObject dans la scène si l'item est sélectionné
            if (!ShopItemManager.Instance.GetItemState(1))
            {
                if (LanterneToDisable != null)
                {
                    LanterneToDisable.SetActive(false);
                }
                else
                {
                    Debug.LogWarning("Le GameObject à désactiver n'est pas assigné.");
                }
            }

            // Index 2 : Augmenter la vie dans le script Health sur le joueur
            if (ShopItemManager.Instance.GetItemState(2))
            {
                Health healthScript = player.GetComponent<Health>();
                if (healthScript != null)
                {
                    healthScript.currentLives += 3;  // Augmente la vie de 10 (par exemple)
                }
                else
                {
                    Debug.LogWarning("Le script 'Health' n'a pas été trouvé sur le joueur.");
                }
            }

            // Index 3 : Désactiver un script sur le joueur
            if (!ShopItemManager.Instance.GetItemState(3))
            {
                // Remplace 'ScriptToDisable' par le nom du script que tu veux désactiver
                Grab script = player.GetComponent<Grab>();
                if (script != null)
                {
                    script.enabled = false;
                }
                else
                {
                    Debug.LogWarning("Le script 'ScriptToDisable' n'a pas été trouvé sur le joueur.");
                }

                if (CramponToDisable != null)
                {
                    CramponToDisable.SetActive(false);
                }
                else
                {
                    Debug.LogWarning("Le GameObject à désactiver n'est pas assigné.");
                }
            }
        }
        else
        {
            Debug.LogError("ShopItemManager n'a pas été trouvé dans la scène.");
        }
    }
}
