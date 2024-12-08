using UnityEngine;

public class PlayerDialogueTriggerCinematic : MonoBehaviour
{
    public DialogueController dialogueController; // Référence au contrôleur de dialogue
    public NPCDialogue currentNPCDialogue; // Référence au dialogue actuel du PNJ
    private bool isNearNPC = false; // Indique si le joueur est proche d'un PNJ
    public int index = 0;


   private void Update()
    {
        if  (Input.GetKeyDown(KeyCode.E) && index <=1)
        {
            // Afficher ou masquer le dialogue
            if (dialogueController.isDialogueVisible)
            {
                dialogueController.HideDialogue();
                GetComponent<Animator>().SetTrigger("DialogueFini");
                index++;
            }
            else
            {
                dialogueController.ShowDialogue(currentNPCDialogue.dialogue);
                index++;
            }
        }
    }
}
