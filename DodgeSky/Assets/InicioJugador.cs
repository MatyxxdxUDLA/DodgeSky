using System;
using UnityEngine;

public class InicioJugador : MonoBehaviour
{
    /*
    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");
        Instantiate(SelectionManager.Instance.personajes[indexJugador].personajeJugable, transform.position, Quaternion.identity);
    }
    */

    void Start()
    {
        int indexJugador = PlayerPrefs.GetInt("JugadorIndex");

        // Verificar si el índice está dentro del rango válido
        if (SelectionManager.Instance.personajes == null || 
            indexJugador < 0 || 
            indexJugador >= SelectionManager.Instance.personajes.Count)
        {
            Debug.LogError("Índice de jugador fuera de rango o lista de personajes no inicializada.");
            return;
        }

        // Verificar si el prefab del personaje es válido
        GameObject prefabPersonaje = SelectionManager.Instance.personajes[indexJugador].personajeJugable;
        if (prefabPersonaje == null)
        {
            Debug.LogError("Prefab del personaje seleccionado es nulo.");
            return;
        }

        // Instanciar el personaje seleccionado
        GameObject personaje = Instantiate(prefabPersonaje, transform.position, Quaternion.identity);

        if (personaje == null)
        {
            Debug.LogError("Error al instanciar el personaje.");
            return;
        }

        // Asignar el transform del personaje a la cámara
        CameraFollow cameraFollow = Camera.main.GetComponent<CameraFollow>();
        if (cameraFollow != null)
        {
            cameraFollow.myTarget = personaje.transform;
        }
        else
        {
            Debug.LogError("No se encontró el script CameraFollow en la cámara principal.");
        }
    }
}
