using UnityEngine;
using TMPro;

public class PuntajePantalla : MonoBehaviour
{
    [SerializeField] private Puntaje puntajeJugador;
    [SerializeField] private TextMeshProUGUI textoPuntaje;

    private void OnEnable()
    {
        puntajeJugador.alActualizarPuntaje += ActualizarTexto;
    }

    private void OnDisable()
    {
        puntajeJugador.alActualizarPuntaje -= ActualizarTexto;
    }

    private void ActualizarTexto()
    {
        textoPuntaje.text = "Puntos: " + puntajeJugador.puntosTotales.ToString();
    }
}