using UnityEngine;

public class PlayerDialogueTrigger : MonoBehaviour
{
    public DialogueController dialogueController; // Référence au contrôleur de dialogue
    private NPCDialogue currentNPCDialogue; // Référence au dialogue actuel du PNJ
    private bool isNearNPC = false; // Indique si le joueur est proche d'un PNJ

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("NPCTUTO"))
        {
            currentNPCDialogue = other.GetComponent<NPCDialogue>();
            isNearNPC = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC") || other.CompareTag("NPCTUTO"))
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

            if (currentNPCDialogue.CompareTag("NPCTUTO"))
            {
                if (dialogueController.isDialogueVisible)
                {
                    // Si le dialogue est visible, le masquer
                    dialogueController.HideDialogue();
                }
                else
                {
                    // Si le dialogue n'est pas visible, afficher le dialogue et le tutoriel
                    dialogueController.ShowDialogueWithTutorial(currentNPCDialogue.dialogue);
                }
            }
            else
            {
                // Affiche uniquement la bulle de dialogue classique
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
}
