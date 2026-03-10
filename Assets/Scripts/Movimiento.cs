using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float alturaSalto = 4f;
    [SerializeField] private LayerMask capaDeSalto;
    [SerializeField] private LayerMask capaDeEscalera;
    [SerializeField] private float velocidadEscalar = 5f;
    [Range(0, 1)]
    [SerializeField] private float modificadorVelSalto = 0.5f;

    [Header("Configuración de Saltos")]
    [Tooltip("Cantidad total de saltos permitidos (Ej: 3 = 1 normal + 2 extras)")]
    [SerializeField] private int saltosMaximos = 3;

    private int saltosRestantes;
    private bool enSuelo;
    private float escalaGravedad = 1f;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        escalaGravedad = rb.gravityScale;
    }

    void Update()
    {
        // 1. Verificar si el jugador está tocando el suelo
        enSuelo = boxCollider.IsTouchingLayers(capaDeSalto);

        // 2. Reiniciar el contador de saltos si está en el suelo y NO está moviéndose hacia arriba 
        
        if (enSuelo && rb.velocity.y <= 0.01f)
        {
            saltosRestantes = saltosMaximos;
        }
        // Si el personaje se deja caer de una plataforma sin saltar
        else if (!enSuelo && saltosRestantes == saltosMaximos)
        {
            // Ya no está tocando el piso, por lo que pierde su salto normal (base).
            saltosRestantes = saltosMaximos - 1;
        }
    }

    public void Moverse(float movimientoX)
    {
        rb.velocity = new Vector2(movimientoX * velocidadCaminata, rb.velocity.y);
        animator.SetBool("estaCorriendo", movimientoX != 0);
    }

    public void Saltar(bool debeSaltar)
    {
        // Si el botón está presionado debeSaltar es verdadero
        if (debeSaltar)
        {
            // Verificamos si podemos saltar 
            if (enSuelo || (!enSuelo && saltosRestantes > 0))
            {
                EjecutarFuerzaSalto();
                saltosRestantes--;
            }
        }
        // Si sueltan el boton de salto ya no debe seguir saltando
        else
        {
            // Se detiene el salto si el jugador va hacia arriba
            if (rb.velocity.y > 0)
            {
                // Multiplicamos la velocidad vertical actual por el modificador 
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * modificadorVelSalto);
            }
        }
    }

    //  para no repetir la fórmula física dos veces
    private void EjecutarFuerzaSalto()
    {
        float gravedad = Physics2D.gravity.y * rb.gravityScale;
        float velocidadInicialSalto = Mathf.Sqrt(-2f * gravedad * alturaSalto);

        // Para saltos múltiples se reinicia la velocidad en y a 0 antes de aplicar la fuerza.
        // Si no se hace, saltar mientras se cae resta fuerza y no se alcanza la altura deseada.
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.velocity = new Vector2(rb.velocity.x, velocidadInicialSalto);
    }

    public void VoltearTransform(float movimientoX)
    {
        transform.localScale = new Vector2(
            Mathf.Sign(movimientoX) * Mathf.Abs(transform.localScale.x),
            transform.localScale.y
            );
    }

    public void Escalar(float movimientoY)
    {
        if (!boxCollider.IsTouchingLayers(capaDeEscalera))
        {
            rb.gravityScale = escalaGravedad;
            return;
        }
        rb.velocity = new Vector2(rb.velocity.x, movimientoY * velocidadEscalar);
        rb.gravityScale = 0f;
    }

}