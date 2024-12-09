using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Personaje")]
public class CharacterSelection : ScriptableObject
{
    public GameObject personajeJugable;
    public Sprite imagen;
    public string nombre;
}
