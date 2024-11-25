using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
        //LevelManager.Instance.LoadScene("SampleScene", "CrossFade");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
