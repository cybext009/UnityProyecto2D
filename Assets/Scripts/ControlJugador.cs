using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlJugador : MonoBehaviour
{
    private Movimiento movimiento;
    private Vector2 entradaControl;
    private LanzaProyectiles lanzaProyectiles;

    // Start is called before the first frame update
    void Start()
    {
        movimiento = GetComponent<Movimiento>();
        lanzaProyectiles = GetComponent<LanzaProyectiles>();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento.Moverse(entradaControl.x);

        if(Mathf.Abs(entradaControl.x)>Mathf.Epsilon)
        {
            movimiento.VoltearTransform(entradaControl.x);
        }
    }

    public void Almoverse(InputAction.CallbackContext context)
    {
        entradaControl = context.ReadValue<Vector2>();
    }

    public void AlSaltar(InputAction.CallbackContext context)
    {
        movimiento.Saltar(context.action.triggered);
    }

    public void AlLanzar(InputAction.CallbackContext context)
    {
        // Valida que el botón se haya presionado y no soltado
        if (!context.action.triggered) { return; }

        // Manda un mensaje a la consola para saber si el botón realmente está funcionando
        Debug.Log("¡El clic funciona y el jugador intenta disparar!");

        // Manda a llamar a tu script LanzaProyectiles
        GetComponent<LanzaProyectiles>().Lanzar();
    }
}
