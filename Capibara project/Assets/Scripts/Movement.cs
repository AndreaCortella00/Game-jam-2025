using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed = 5f;            // Velocità massima
    public float acceleration = 2f;        // Accelerazione per simulare il movimento subacqueo
    public float deceleration = 3f;        // Decelerazione per simulare la resistenza dell'acqua
    private Vector2 currentVelocity;       // Velocità corrente del minisottomarino

    void Update()
    {
        // Input per il movimento orizzontale (sinistra/destra)
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D o frecce sinistra/destra
        // Input per il movimento verticale (su/giù)
        float moveVertical = Input.GetAxis("Vertical");     // W/S o frecce su/giù

        // Direzione di movimento
        Vector2 targetDirection = new Vector2(moveHorizontal, moveVertical).normalized;

        // Accelerazione se c'è input
        if (targetDirection.magnitude > 0.1f)
        {
            // Interpoliamo la velocità corrente verso la velocità desiderata con accelerazione
            currentVelocity = Vector2.Lerp(currentVelocity, targetDirection * maxSpeed, acceleration * Time.deltaTime);
        }
        else
        {
            // Se non c'è input, deceleriamo gradualmente fino a fermarci
            currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, deceleration * Time.deltaTime);
        }

        // Muoviamo il minisottomarino con la velocità corrente
        transform.position += (Vector3)currentVelocity * Time.deltaTime;
    }
}