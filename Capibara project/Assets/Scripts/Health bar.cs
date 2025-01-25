using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour 
{
    [Header("Health Settings")]
    public float maxHealth = 100f; // Vita massima
    public float currentHealth; // Vita attuale
    public float healthDecrementRate = 5f; // Velocità di decremento vita (per secondo)

    [Header("UI Settings")]
    public Slider healthSlider; // Riferimento alla barra della vita

    void Start()
    {
        // Inizializza la vita al massimo
        currentHealth = maxHealth;

        // Configura il valore massimo dello slider
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    void Update()
    {
        // Decrementa la vita nel tempo
        if (currentHealth > 0)
        {
            currentHealth -= healthDecrementRate * Time.deltaTime;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Assicura che la vita sia compresa tra 0 e maxHealth

            // Aggiorna la barra della vita
            if (healthSlider != null)
            {
                healthSlider.value = currentHealth;
            }
        }
        else
        {
            Debug.Log("Game Over!"); // Messaggio quando la vita finisce
        }
    }
}
