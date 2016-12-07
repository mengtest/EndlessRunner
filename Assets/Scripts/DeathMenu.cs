using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

    public string MainMenuLevel;

    public void RestartGame()
    {
        FindObjectOfType<GameManager>().ResetPlayer();     
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(MainMenuLevel);
    }
}
