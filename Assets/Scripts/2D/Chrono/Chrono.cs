using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Chrono : MonoBehaviour
{
    public Text chronoText; // Référence au Text UI pour afficher le chrono
    public Button startButton; // Bouton pour commencer le chrono

    private float timer = 0f; // Temps écoulé
    private bool isRunning = false; // Indique si le chrono est actif

    public static Chrono instance; // Instance unique du ChronoManager

    void Awake()
    {
        // Vérifie s'il existe déjà une instance de ChronoManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Rend l'objet persistant entre les scènes
        }
        else if (instance != this)
        {
            Destroy(gameObject); // Détruit le duplicata
        }
    }

    void Start()
    {
        // Associe le bouton au début du chrono
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartChrono);
        }
        // Initialise l'affichage du chrono
        UpdateChronoDisplay();
    }

    void OnEnable()
    {
        // S'abonne à l'événement de chargement de scène
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Se désabonne de l'événement de chargement de scène
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime; // Ajoute le temps écoulé depuis la dernière frame
            UpdateChronoDisplay();  // Met à jour l'affichage
        }
        print(timer);
    }

    public void StartChrono()
    {
        isRunning = true;
        timer = 0f; // Réinitialise le chrono
    }

    public void StopChrono()
    {
        isRunning = false; // Arrête le chrono
    }

    private void UpdateChronoDisplay()
    {
        if (chronoText != null)
        {
            int minutes = Mathf.FloorToInt(timer / 60F);
            int seconds = Mathf.FloorToInt(timer % 60F);
            int milliseconds = Mathf.FloorToInt((timer * 1000F) % 1000F);
            chronoText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Réassigne le Text UI du chronomètre dans la nouvelle scène
        GameObject textObj = GameObject.Find("NomDuTextUI");
        if (textObj != null)
        {
            chronoText = textObj.GetComponent<Text>();
            UpdateChronoDisplay(); // Met à jour l'affichage avec le temps actuel
        }

        // Réassigne le bouton de démarrage si nécessaire
        GameObject buttonObj = GameObject.Find("NomDuBoutonStart");
        if (buttonObj != null)
        {
            startButton = buttonObj.GetComponent<Button>();
            startButton.onClick.AddListener(StartChrono);
        }
    }
}
