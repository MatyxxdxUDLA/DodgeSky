using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime = 2.0f; // Tiempo de vida de la explosión en segundos

    void Start()
    {
        Destroy(gameObject, lifetime); // Destruye este objeto después del tiempo especificado
    }
}
