using System.Collections;
using UnityEngine;

public class AvionMovimiento : MonoBehaviour
{
    public float maxSpeed; // Velocidad base
    public float rotSpeed; // Velocidad de rotación
    private float velocidadActual; // Velocidad actual del avión
    private bool aumentandoVelocidad = false; // Bandera para evitar múltiples aumentos simultáneos

    void Start()
    {
        velocidadActual = maxSpeed; // Inicializa la velocidad actual con la velocidad base
    }

    void FixedUpdate()
    {
        // Rotación
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        // Movimiento
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, velocidadActual * Time.deltaTime, 0);
        pos += rot * velocity;
        transform.position = pos;
    }

    public void AumentarVelocidad(float incremento, float duracion)
    {
        if (!aumentandoVelocidad)
        {
            StartCoroutine(AumentoVelocidadCoroutine(incremento, duracion));
        }
    }

    private IEnumerator AumentoVelocidadCoroutine(float incremento, float duracion)
    {
        aumentandoVelocidad = true;
        velocidadActual += incremento; // Aumenta la velocidad
        yield return new WaitForSeconds(duracion); // Espera el tiempo especificado
        velocidadActual = maxSpeed; // Restaura la velocidad base
        aumentandoVelocidad = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {
            float incrementoVelocidad = 3f; // Incremento de velocidad
            float duracion = 5f; // Duración del aumento en segundos
            AumentarVelocidad(incrementoVelocidad, duracion);

            Destroy(collision.gameObject); // Elimina el Power-Up
        }
    }
}
