using UnityEngine;

public class Trampolin : MonoBehaviour
{
    [Header("Configuración de Físicas")]
    // Permite balancear qué tan alto salta el jugador desde Unity como parametro
    [SerializeField] private float fuerzaRebote = 15f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Verificamos si detecta el choque
        Debug.Log("El trampolín tocó a: " + collision.gameObject.name);

        Rigidbody2D rb = collision.attachedRigidbody;

        if (rb != null)
        {
            // 2. Verificamos si aplicó la fuerza
            Debug.Log("¡Fuerza aplicada al Rigidbody!");
            rb.velocity = new Vector2(rb.velocity.x, fuerzaRebote);
        }
        else
        {
            // 3. Verificamos si no encontró el Rigidbody
            Debug.LogWarning("No se encontró el Rigidbody en " + collision.gameObject.name);
        }
    }
}