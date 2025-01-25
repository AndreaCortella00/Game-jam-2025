using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 5f;            // Velocit� massima raggiungibile
    public float acceleration = 3f;        // Velocit� di accelerazione
    public float deceleration = 4f;        // Velocit� di decelerazione

    private Vector2 currentVelocity;       // Velocit� corrente
    private Rigidbody2D rb;                // Riferimento al Rigidbody2D del minisottomarino

    void Start()
    {
        // Otteniamo il riferimento al Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input per il movimento orizzontale (destra/sinistra)
        float moveHorizontal = Input.GetAxis("Horizontal");   // A/D o frecce sinistra/destra
        // Input per il movimento verticale (su/gi�)
        float moveVertical = Input.GetAxis("Vertical");       // W/S o frecce su/gi�

        // Direzione di movimento in funzione dell'input
        Vector2 targetDirection = new Vector2(moveHorizontal, moveVertical).normalized;

        // Accelerazione se c'� un input
        if (targetDirection.magnitude > 0.1f)
        {
            // Interpoliamo la velocit� corrente verso la velocit� desiderata con accelerazione
            currentVelocity = Vector2.Lerp(currentVelocity, targetDirection * maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            // Se non c'� input, deceleriamo gradualmente fino a fermarci
            currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, deceleration * Time.deltaTime);
        }

        // Applichiamo la velocit� corrente al Rigidbody2D per il movimento
        rb.linearVelocity = currentVelocity;
    }
}