using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolaMundo : MonoBehaviour
{
    [SerializeField] private string mensaje;

    // Método publico a utilizar en otras clases
    public void Saludar()
    {
    
        Debug.Log(mensaje);
        
    }
}
