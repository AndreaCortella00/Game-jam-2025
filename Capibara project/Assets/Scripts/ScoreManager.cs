using UnityEngine;
using UnityEngine.UI;

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
    }

    // Funzione per aggiungere punteggio
    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;  // Aggiungiamo il punteggio al totale
    }
}

