using UnityEngine;

// Controlador del jugador que permite saltar y moverse horizontalmente

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f; //Fuerza del salto
    private Rigidbody2D rb; // Referencia al Rigidbody2D del jugador
    private bool isGrounded; // Indica si el jugador esta en el suelo
    public float speed = 5f; // Velocidad de movimiento del jugador

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener el componente Rigidbody2D
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Si se presiona la barra espaciadora y el jugador esta en el suelo
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Aplicar fuerza de salto
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y); // Mover al jugador horizontalmente a una velocidad constante
    }

    // Deteccion de colisiones
    private void OnCollisionEnter2D(Collision2D collision) // Detectar colision con el suelo
    {
        if (collision.gameObject.CompareTag("Ground")) // Si el objeto con el que colisiona tiene la etiqueta "Ground"
        {
            isGrounded = true; // El jugador esta en el suelo
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // Detectar cuando el jugador deja de colisionar con el suelo
    {
        if (collision.gameObject.CompareTag("Ground")) // Si el objeto con el que deja de colisionar tiene la etiqueta "Ground"
        {
            isGrounded = false; // El jugador ya no esta en el suelo
        }
    }
}
