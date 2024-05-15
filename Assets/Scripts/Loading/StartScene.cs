using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {
    [Tooltip("로딩 중 불러올 캔버스입니다.")]
    [SerializeField] GameObject loadingCanvas;
    GameObject canvas;

    public void Load(string sceneName) {
        if (LoadingManager.instance != null)
            Destroy(LoadingManager.instance.gameObject);
        canvas = Instantiate(loadingCanvas);
        StartCoroutine(Loading(sceneName, 0.5f));
        DontDestroyOnLoad(canvas);
    }

    IEnumerator Loading(string sceneName, float time) {
        yield return new WaitForSeconds(time);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        while (!async.isDone) {
            yield return null;
            if (async.progress >= 0.9f) {
                if (canvas.TryGetComponent(out Animator animator))
                    animator.SetTrigger("Finished");
                async.allowSceneActivation = true;
                yield break;
            }
        }
    }
}
