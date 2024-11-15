using UnityEngine;

public class PlayerDialogueTrigger : MonoBehaviour
{
    public DialogueController dialogueController; // Référence au contrôleur de dialogue
    private NPCDialogue currentNPCDialogue; // Référence au dialogue actuel du PNJ
    private bool isNearNPC = false; // Indique si le joueur est proche d'un PNJ

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            currentNPCDialogue = other.GetComponent<NPCDialogue>();
            isNearNPC = true;
        }
    }

   private void OnTriggerExit2D(Collider2D other)
{
    if (other.CompareTag("NPC"))
        {
            dialogueController.HideDialogue();
            currentNPCDialogue = null;
            isNearNPC = false;
        }
}


   private void Update()
    {
        if (isNearNPC && currentNPCDialogue != null && Input.GetKeyDown(KeyCode.E))
        {
            // Désactiver la bulle de signalisation du PNJ
            if (currentNPCDialogue.signalBubble != null)
            {
                currentNPCDialogue.signalBubble.SetActive(false);
            }

            // Afficher ou masquer le dialogue
            if (dialogueController.isDialogueVisible)
            {
                dialogueController.HideDialogue();
            }
            else
            {
                dialogueController.ShowDialogue(currentNPCDialogue.dialogue);
            }
        }
    }
}
