using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuSeleccionPersonaje : MonoBehaviour
{
    private int index;
    [SerializeField] private Image imagen;
    [SerializeField] private TextMeshProUGUI nombre;
    private SelectionManager selectionManager;

    /*
    private void Start()
    {
        selectionManager = SelectionManager.Instance;
        index = PlayerPrefs.GetInt("JugadorIndex");
        if(index > selectionManager.personajes.Count -1)
        {
            index = 0;
        }
        CambiarPantalla();
    }
    */
    private void Start()
{
    selectionManager = SelectionManager.Instance;

    // Validar que la lista no esté vacía
    if (selectionManager.personajes == null || selectionManager.personajes.Count == 0)
    {
        Debug.LogError("La lista de personajes está vacía o no se inicializó correctamente.");
        return; // Salimos para evitar errores
    }

    // Obtener el índice de PlayerPrefs y ajustarlo si está fuera de rango
    index = PlayerPrefs.GetInt("JugadorIndex", 0);
    if (index < 0 || index >= selectionManager.personajes.Count)
    {
        index = 0;
    }

    CambiarPantalla();
}


    private void CambiarPantalla()
    {
        PlayerPrefs.SetInt("JugadorIndex", index);
        imagen.sprite = selectionManager.personajes[index].imagen;
        nombre.text = selectionManager.personajes[index].nombre;
    }

    public void SiguientePersonaje()
    {
        if(index == selectionManager.personajes.Count -1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        CambiarPantalla();
    }

    public void AnteriorPersonaje()
    {
        if(index == selectionManager.personajes.Count -1)
        {
            index = 0;
        }
        else
        {
            index -= 1;
        }
        CambiarPantalla();
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
