using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMenu : MonoBehaviour
{
    public Animator canvasMenu;
    [SerializeField] Canvas canvas;
    [SerializeField] StartScene startScene;

    public string thisScene;

    public void goMenu()
    {
        startScene.Load("Menu");
    }

    public void Restart()
    {
        startScene.StartStage(thisScene);
    }

    public void Continue()
    {
        canvasMenu.SetTrigger("out");
        StartCoroutine(Inactive());
    }

    IEnumerator Inactive() {
        yield return new WaitForSeconds(1.0f);
        canvas.gameObject.SetActive(false);
    }

    public void End()
    {
        Application.Quit();

    }

}
