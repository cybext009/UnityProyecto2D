using UnityEngine;

public class ItemPuntos : MonoBehaviour
{
    [SerializeField] private int puntosQueOtorga = 10;

   
    [SerializeField] private AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Puntaje puntajeJugador = collision.GetComponent<Puntaje>();

        if (puntajeJugador != null)
        {
            // Sumamos los puntos primero
            puntajeJugador.SumarPuntos(puntosQueOtorga);

            ReproducirSonido();
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            sprite.enabled = false;
            Destroy(gameObject, audioClip.length);
        }
    }

    private void ReproducirSonido()
    {
        if (audioClip == null) { return; }

        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
    }
}