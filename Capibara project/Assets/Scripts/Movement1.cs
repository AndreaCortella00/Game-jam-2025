using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement1 : MonoBehaviour
{
    public float maxSpeed = 5f;            // Velocità massima
    public float acceleration = 2f;        // Accelerazione per simulare il movimento subacqueo
    public float deceleration = 3f;        // Decelerazione per simulare la resistenza dell'acqua
    private Vector2 currentVelocity;       // Velocità corrente del minisottomarino
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public HealthSystem healthSystem;

    void Start()
    {
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
        transform.position += (Vector3)currentVelocity * Time.deltaTime;

        // Impostiamo l'animazione orizzontale
        animator.SetFloat("xVelocity", Mathf.Abs(moveHorizontal));

        // Flippiamo lo sprite in base alla direzione del movimento orizzontale
        if (moveHorizontal < 0f)
        {
            spriteRenderer.flipX = true;  // Flip a sinistra
        }
        else if (moveHorizontal > 0f)
        {
            spriteRenderer.flipX = false; // Flip a destra
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            healthSystem.TakeDamage(10f);  // Riduce la salute di 10 quando colpisce un nemico
        }
        else
        {
            if (collision.gameObject.CompareTag("Heal"))
            {
                healthSystem.Heal(10f);  // Riduce la salute di 10 quando colpisce un nemico
            }
        }
    }
    
    }
