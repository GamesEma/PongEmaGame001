using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float startSpeed = 5f; // Velocidad inicial de la pelota
    public float speedIncreaseFactor = 1.1f; // Factor de aumento de velocidad al rebotar
    public Vector2 startDirection = new Vector2(1f, 0f); // Dirección inicial de la pelota

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D de la pelota
    }

    private void Start()
    {
        StartBall();
    }

    public void StartBall()
    {
        rb.velocity = startDirection.normalized * startSpeed; // Iniciar la pelota con la velocidad y dirección iniciales
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cambiar la dirección de la pelota al rebotar en la raqueta o en los bordes del área de juego
        Vector2 newDirection = Vector2.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
        rb.velocity = newDirection * startSpeed * speedIncreaseFactor;
    }
}

