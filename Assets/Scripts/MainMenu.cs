using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string PlayGameLevel;

    public void PlayGame()
    {
        SceneManager.LoadScene(PlayGameLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
