using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
    public GameObject canvasMenu;

    public string thisScene;

    public void goMenu()
    {
        SceneManager.LoadScene("Menu");
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
