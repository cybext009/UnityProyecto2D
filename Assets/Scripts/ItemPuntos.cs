using UnityEngine;

public class ItemPuntos : MonoBehaviour
{
    // Permite configurar los puntos desde el editor
    [SerializeField] private int puntosQueOtorga = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Puntaje puntajeJugador = collision.GetComponent<Puntaje>();

        if (puntajeJugador != null)
        {
            puntajeJugador.SumarPuntos(puntosQueOtorga);
            Destroy(gameObject);
        }
    }
}