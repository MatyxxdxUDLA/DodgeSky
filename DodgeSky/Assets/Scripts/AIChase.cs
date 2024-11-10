using System;
using UnityEngine;

public class AIChase : MonoBehaviour
{
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
}
