using UnityEngine;

public class Misil : MonoBehaviour
{
    [SerializeField] private float vida;
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
