using System;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    /*
    private Transform target;
    public float speed;        // Velocidad de movimiento hacia el objetivo
    public float rotSpeed;     // Velocidad de rotación

    void Start()
    {
        // Intentamos encontrar el objeto con el tag "Player" solo si existe
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            target = player.transform;
        }
        else
        {
            Debug.LogWarning("No se encontró el objeto con el tag 'Player' en la escena.");
        }
    }

    void Update()
    {
        // Continuamente verificamos si el target existe antes de intentar seguirlo
        if (target != null)
        {
            // Calcula la dirección hacia el objetivo
            Vector3 direction = target.position - transform.position;
            direction.Normalize();

            // Obtiene el ángulo deseado de rotación
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 45f;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

            // Rota gradualmente hacia el objetivo
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);

            // Mueve el objeto en la dirección de la rotación actual
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else
        {
            // Opcional: detiene o destruye el proyectil si el objetivo no existe
            // Destroy(gameObject); // Destruye este objeto (el proyectil) si no hay objetivo
        }
    }
    */

    public Transform target;       // El objetivo a seguir (el avión)
    public float speed = 5f;       // Velocidad del misil
    public float rotateSpeed = 200f; // Velocidad de rotación del misil

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Busca automáticamente el objeto con el tag "Player" si no se asigna manualmente el objetivo
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
                target = player.transform;
        }
    }

    void FixedUpdate()
    {
        if (target == null) return; // Si no hay objetivo, no hacer nada

        // Calcula la dirección hacia el objetivo
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();

        // Calcula el ángulo de rotación hacia el objetivo
        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        // Aplica la rotación y mueve el misil hacia adelante
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        rb.linearVelocity = transform.up * speed;
    }
}
