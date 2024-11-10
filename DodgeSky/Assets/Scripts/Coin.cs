using UnityEngine;

public class Coin : MonoBehaviour
{
    public int valor = 1;

    void Start()
    {
        Destroy(gameObject, 5);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.SumarPuntos(valor);
            Destroy(this.gameObject);
        }
    }
}

