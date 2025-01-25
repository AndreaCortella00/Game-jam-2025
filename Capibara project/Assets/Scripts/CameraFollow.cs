using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;             // Il riferimento al giocatore
    public float smoothSpeed = 0.125f;   // Velocità di "lerping" (smussamento del movimento)
    public Vector3 offset;              // Offset tra la telecamera e il giocatore
    public float minX, maxX, minY, maxY; // Limiti per il movimento della telecamera

    void LateUpdate()
    {
        // La posizione desiderata della telecamera
        Vector3 desiredPosition = player.position + offset;

        // Applicare i limiti per evitare che la telecamera esca dai bordi del mondo
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minX, maxX);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minY, maxY);

        // Spostamento fluido della telecamera verso la posizione desiderata
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Impostiamo la nuova posizione della telecamera
        transform.position = smoothedPosition;
    }
}
