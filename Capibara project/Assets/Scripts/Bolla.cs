using UnityEngine;
using UnityEngine.SceneManagement;

public class Bolla : MonoBehaviour
{
    
    public HealthSystem healthSystem;
    // Quando il giocatore entra in collisione con la moneta
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Controlla se l'oggetto che ha fatto la collisione � il giocatore
        {
            // Aumenta vita
            healthSystem.Heal(10f);

            // Distrugge la moneta (opzionale: puoi farla nascondere o creare un'animazione)
            Destroy(gameObject);
        }
    }
}

