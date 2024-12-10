using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueController : MonoBehaviour
{
    public GameObject dialogueBubble;   // La bulle de dialogue

    public GameObject tutorielCanva;
    public TextMeshProUGUI dialogueText; // Texte de dialogue à afficher
    public bool isDialogueVisible = false; // Indicateur pour savoir si le dialogue est visible
    private string currentDialogue;     // Texte actuel à afficher

    public float textSpeed = 0.05f;     // Vitesse d'apparition des caractères
    private GameObject currentSignalBubble;
    public AudioSource typingSound;

    void Start()
    {
        dialogueBubble.SetActive(false);
        tutorielCanva.SetActive(false);
    }

    public void ShowDialogue(string dialogue)
    {
        currentDialogue = dialogue;
        dialogueBubble.SetActive(true);
        isDialogueVisible = true;
        StartCoroutine(TypeText());
    }

    public void ShowDialogueWithTutorial(string dialogue)
    {
        currentDialogue = dialogue;
        dialogueBubble.SetActive(true);
        tutorielCanva.SetActive(true);
        isDialogueVisible = true;
        StartCoroutine(TypeText());
    }

    public void HideDialogue()
    {
        StopAllCoroutines();
        dialogueBubble.SetActive(false);
        tutorielCanva.SetActive(false);
        dialogueText.text = "";
        isDialogueVisible = false;

        if (typingSound != null && typingSound.isPlaying)
        {
            typingSound.Stop();
        }
    }

    private IEnumerator TypeText()
    {
        dialogueText.text = "";

        if (typingSound != null && !typingSound.isPlaying)
        {
            typingSound.Play();
        }

        foreach (char letter in currentDialogue.ToCharArray())
        {
            if (!isDialogueVisible)
            {
                yield break;
            }


            dialogueText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }

        // Arrête le son à la fin de la frappe
        if (typingSound != null && typingSound.isPlaying)
        {
            typingSound.Stop();
        }

        if (currentSignalBubble != null)
        {
            currentSignalBubble.SetActive(false);
        }
    }
}
