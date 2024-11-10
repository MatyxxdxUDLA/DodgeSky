using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(int puntosASumar)
    {
        puntosTotales += puntosASumar;
        Debug.Log(puntosTotales);
    }
}

