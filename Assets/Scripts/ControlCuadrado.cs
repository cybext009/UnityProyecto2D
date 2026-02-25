using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCuadrado : MonoBehaviour
{
   
    private HolaMundo holaMundo;

    void Start()
    {
        // obtener el componenete Hola mundo
        holaMundo = GetComponent<HolaMundo>();
        // llamar al metodo saludar
        holaMundo.Saludar();
    }

}
