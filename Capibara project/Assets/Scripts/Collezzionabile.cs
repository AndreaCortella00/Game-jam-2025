using UnityEngine;
using UnityEngine.SceneManagement;

public class Collezzionabile : MonoBehaviour
{
    public int scoreValue = 10;  // Punteggio che il giocatore ottiene raccogliendo la moneta

    // Quando il giocatore entra in collisione con la moneta
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Controlla se l'oggetto che ha fatto la collisione è il giocatore
        {
            // Aumenta il punteggio del giocatore
            ScoreManager.instance.AddScore(scoreValue);

            // Distrugge la moneta (opzionale: puoi farla nascondere o creare un'animazione)
            Destroy(gameObject);
        }
    }
}

