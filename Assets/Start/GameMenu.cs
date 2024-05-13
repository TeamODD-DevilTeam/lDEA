using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
    public GameObject canvasMenu;
    public GameObject gamePause;
    public GameObject gameRestart;
    public GameObject gameContinue;
    public GameObject gameEnd;

    public string thisScene;

    public void Pause()
    {
        thisScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 0f;
        canvasMenu.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(thisScene);
    }

    public void Continue()
    {
        canvasMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void End()
    {
        Application.Quit();

    }

}
