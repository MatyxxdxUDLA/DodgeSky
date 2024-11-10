using Unity.VisualScripting;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;
    [SerializeField] private float daño;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.up * velocidad * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Misil"))
        {
            other.GetComponent<Misil>().TomarDaño(daño);
            Destroy(gameObject);
        }
    }
}
