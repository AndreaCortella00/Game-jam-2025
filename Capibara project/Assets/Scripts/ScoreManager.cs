using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // Aggiungi questo namespace per la gestione delle scene

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;   // Riferimento alla singola istanza di ScoreManager (singleton)
    public int score = 0;                  // Punteggio corrente del giocatore
    public Text scoreText;                 // Riferimento al componente UI Text che mostra il punteggio

    void Awake()
    {
        // Assicuriamoci che ci sia una sola istanza di ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Se esiste già un'istanza, distruggi questa
        }
    }

    void Update()
    {
        // Aggiorniamo il punteggio visualizzato
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
        if (score >= 160)
        {
            LoadVictoryScene();
        }
    }

    // Funzione per aggiungere punteggio
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;  // Aggiungiamo il punteggio al totale
    }

    // Funzione per caricare la scena di vittoria
    void LoadVictoryScene()
    {
        // Assicurati che "VictoryScene" sia il nome della tua scena di vittoria
        SceneManager.LoadScene("VictoryScene");
    }
}

