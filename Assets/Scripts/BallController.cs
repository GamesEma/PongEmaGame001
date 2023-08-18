using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float startSpeed = 5f; // Velocidad inicial de la pelota

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
        // Establecer velocidad inicial y dirección aleatoria
        rb.velocity = new Vector2(startSpeed, Random.Range(-startSpeed, startSpeed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Cambiar dirección horizontal y aumentar velocidad
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y) * 1.05f;
        }
        else
        {
            // Cambiar la dirección de la pelota al rebotar en los bordes del área de juego
            rb.velocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal) * 1.05f;
        }
    }
}
