using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Librería necesaria para cambiar escenas

public class MenuPrincipal : MonoBehaviour
{
    public void IniciarJuego()
    {
      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CerrarAplicacion()
    {
      
        Application.Quit();
    }
}