using UnityEngine;

public class MuoviEnemy : MonoBehaviour
{
    public float speed = 2f;          // Velocità di movimento del nemico
    public float moveDistance = 5f;   // Distanza massima che il nemico si sposterà avanti/indietro o su/giù
    private Vector2 startPosition;    // Posizione iniziale del nemico

    // Opzioni per movimento
    public bool moveHorizontally = true;   // Abilita il movimento orizzontale
    public bool moveVertically = false;   // Abilita il movimento verticale

    private bool movingRight = true;  // Indica se il nemico sta andando verso destra o sinistra
    private bool movingUp = true;    // Indica se il nemico sta andando verso l'alto o in basso

    private Rigidbody2D rb;           // Riferimento al Rigidbody2D

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Ottieni il Rigidbody2D
        startPosition = transform.position;  // Salva la posizione iniziale
    }

    void Update()
    {
        // Movimento orizzontale
        if (moveHorizontally)
        {
            float moveDirectionX = movingRight ? 1 : -1;
            Vector2 targetPositionX = startPosition + new Vector2(moveDirectionX * moveDistance, 0);
            MoveEnemy(targetPositionX);
        }

        // Movimento verticale
        if (moveVertically)
        {
            float moveDirectionY = movingUp ? 1 : -1;
            Vector2 targetPositionY = startPosition + new Vector2(0, moveDirectionY * moveDistance);
            MoveEnemy(targetPositionY);
        }
    }

    // Funzione per spostare il nemico
    private void MoveEnemy(Vector2 targetPosition)
    {
        float step = speed * Time.deltaTime;

        // Muovi il nemico fino a raggiungere la posizione limite
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, step);

        // Cambia direzione quando il nemico arriva alla posizione limite
        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition.x != startPosition.x) // Se ci stiamo muovendo orizzontalmente
            {
                movingRight = !movingRight;
            }
            else if (targetPosition.y != startPosition.y) // Se ci stiamo muovendo verticalmente
            {
                movingUp = !movingUp;
            }
        }
    }
}

