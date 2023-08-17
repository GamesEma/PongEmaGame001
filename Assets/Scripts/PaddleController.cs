using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento de la raqueta
    public string inputAxis;     // Eje de entrada para controlar la raqueta ("Vertical" o "Vertical2")

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D de la raqueta
    }

    private void Update()
    {
        float moveInput = Input.GetAxis(inputAxis); // Obtener la entrada del eje especificado (Vertical o Vertical2)
        Vector2 moveDirection = new Vector2(0f, moveInput).normalized; // Crear un vector de dirección vertical
        rb.velocity = moveDirection * moveSpeed; // Asignar la velocidad del Rigidbody para mover la raqueta
    }
}
