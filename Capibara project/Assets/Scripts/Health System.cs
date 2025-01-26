using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;        // Salute massima
    private float currentHealth;          // Salute corrente
    public Slider healthBar;              // Barra della vita da assegnare nell'Inspector
    public GameObject deathEffect;        // Oggetto che appare quando il personaggio muore (opzionale)
    public float oxygenLossRate = 1f;     // Velocità di diminuzione della salute (simulando la perdita di ossigeno)

    void Start()
    {
        currentHealth = maxHealth;        // Inizializziamo la salute corrente con la salute massima
        UpdateHealthBar();                 // Inizializziamo la barra della vita
        StartOxygenLoss();
    }
    private void StartOxygenLoss()
    {
        InvokeRepeating("OxygenLoss", 1f, 1f); // Chiama la funzione OxygenLoss ogni secondo
    }

    // Funzione che riduce gradualmente la salute come la perdita di ossigeno
    private void OxygenLoss()
    {
        TakeDamage(oxygenLossRate);  // Riduce la salute di una certa quantità ogni volta che viene chiamato
    }

    // Funzione per danneggiare il personaggio
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;          // Riduciamo la salute
        if (currentHealth < 0f)            // La salute non può scendere sotto zero
        {
            currentHealth = 0f;
        }
        UpdateHealthBar();                 // Aggiorniamo la barra della vita
        CheckDeath();                       // Controlliamo se la salute è a zero (muore)
    }

    // Funzione per guarire il personaggio
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;       // Aumentiamo la salute
        if (currentHealth > maxHealth)     // La salute non può superare il massimo
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();                 // Aggiorniamo la barra della vita
    }

    // Funzione per aggiornare la barra della vita
    private void UpdateHealthBar()
    {
        healthBar.value = currentHealth / maxHealth;   // Impostiamo il valore della barra della vita
    }

    // Funzione per controllare la morte
    private void CheckDeath()
    {
        if (currentHealth <= 0f)
        {
            Die();
        }
    }

    // Funzione che viene chiamata quando il personaggio muore
    private void Die()
    {
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);  // Aggiungi effetto morte (opzionale)
        }
        //Destroy(gameObject); // Rimuoviamo il personaggio dalla scena (opzionale)

        // Assicurati che "LoseScene" sia il nome della tua scena di vittoria
        SceneManager.LoadScene("LoseScene");
    }
}
