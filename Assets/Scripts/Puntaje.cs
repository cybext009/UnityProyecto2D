using System;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public int puntosTotales { get; private set; }
    public event Action alActualizarPuntaje; // Evento

    public void SumarPuntos(int puntos)
    {
        puntosTotales += puntos;
        alActualizarPuntaje?.Invoke(); // Dispara el evento
    }
}