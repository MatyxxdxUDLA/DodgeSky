using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;
    public List<CharacterSelection> personajes;

    public void Awake()
    {
        if(SelectionManager.Instance == null)
        {
            SelectionManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
