
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFader: MonoBehaviour
{
    public void loadByName(string   name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
