using UnityEngine;

public class Movement1 : MonoBehaviour
{
    public float maxSpeed = 5f;            // Velocità massima
    public float acceleration = 2f;        // Accelerazione per simulare il movimento subacqueo
    public float deceleration = 3f;        // Decelerazione per simulare la resistenza dell'acqua
    private Vector2 currentVelocity;       // Velocità corrente del minisottomarino
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    public float stopThreshold = 0.1f;    // Soglia per considerare la velocità orizzontale come zero

    void Start()
    {
        // Inizializziamo i componenti
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
        rb.linearVelocity = currentVelocity; // Usa la fisica di Unity per il movimento

        // Controlliamo se la velocità orizzontale è inferiore alla soglia di stop
        float xVelocity = Mathf.Abs(rb.linearVelocity.x) < stopThreshold ? 0f : Mathf.Clamp(rb.linearVelocity.x / maxSpeed, -1f, 1f);

        // Passa il valore normalizzato all'animatore
        animator.SetFloat("xVelocity", xVelocity);  // Usa la velocità orizzontale normalizzata

        // Inverti l'immagine in base alla direzione orizzontale
        spriteRenderer.flipX = rb.linearVelocity.x < 0f;
    }
}