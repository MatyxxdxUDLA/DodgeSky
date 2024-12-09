using System.Runtime.CompilerServices;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AvionColision : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 7);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<AvionHealth>().TakeDamage(25);
            Destroy(gameObject);
        }
    }
}
