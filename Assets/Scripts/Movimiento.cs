using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    [SerializeField] private float velocidadCaminata = 4f;
    [SerializeField] private float alturaSalto = 4f; 
    [SerializeField] private LayerMask capaDeSalto;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    public void Moverse(float movimientoX)
    {
        rb.velocity = new Vector2(movimientoX * velocidadCaminata, rb.velocity.y);
        animator.SetBool("estaCorriendo", movimientoX != 0);
    }

    public void Saltar(bool debeSaltar)
    {
        if (!boxCollider.IsTouchingLayers(capaDeSalto)) { return; }

        if (debeSaltar)
        {
            // Obtener gravedad real del Rigidbody2D
            float gravedad = Physics2D.gravity.y * rb.gravityScale;

            // Calcular velocidad inicial necesaria para alcanzar la altura deseada
            float velocidadInicialSalto = Mathf.Sqrt(-2f * gravedad * alturaSalto);

            rb.velocity = new Vector2(rb.velocity.x, velocidadInicialSalto);
        }
    }
}