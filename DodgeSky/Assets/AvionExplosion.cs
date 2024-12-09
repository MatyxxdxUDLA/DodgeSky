using UnityEngine;

public class AvionExplosion : MonoBehaviour
{
    public GameObject explosionPrefab; // Arrastra el prefab de la explosión aquí
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Misil"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity); // Crea la explosión
            Destroy(gameObject); // Destruye el avión
        }
    }
    */
    private void OnEnable()
    {
        AvionHealth.OnPlayerDeath += HandleExplosion; // Suscríbete al evento
    }

    private void OnDisable()
    {
        AvionHealth.OnPlayerDeath -= HandleExplosion; // Cancela la suscripción
    }

    private void HandleExplosion()
    {
        // Instancia la explosión
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Destruye el avión después de que se cree la explosión
        Destroy(gameObject);
    }
}
