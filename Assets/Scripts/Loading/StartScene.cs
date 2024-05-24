using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour {
    [Tooltip("로딩 중 불러올 캔버스입니다.")]
    [SerializeField] GameObject loadingCanvas;
    [Tooltip("버튼 효과음을 재생할 컴포넌트입니다.")]
    [SerializeField] AudioSource audioSource;
    GameObject canvas;
    // bool isStage = false;
    float volume = 0;

    public void Quit() {
        Application.Quit();
    }

    public void Load(string sceneName) {
        if (LoadingManager.instance != null)
            Destroy(LoadingManager.instance.gameObject);
        canvas = Instantiate(loadingCanvas);
        StartCoroutine(Loading(sceneName, 0.5f));
        DontDestroyOnLoad(canvas);
        if (MusicPlayer.player.GetCurrentAudio() != MusicPlayer.player.GetDefaultAudio()) MusicPlayer.player.Play(MusicPlayer.player.GetDefaultAudio());
    }

    public void StartStage(string sceneName) {
        Load(sceneName);
        MusicPlayer.player.Play(MusicPlayer.player.GetStageAudio());
        // volume = MusicPlayer.player.GetVolume();
        // audioSource.Play();
        // isStage = true;
        // StartCoroutine(FadeOut());
    }

    IEnumerator Loading(string sceneName, float time) {
        yield return new WaitForSeconds(time);
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false;
        while (!async.isDone) {
            yield return null;
            if (async.progress >= 0.9f) {
                async.allowSceneActivation = true;
                DOTween.KillAll();
                if (canvas.TryGetComponent(out Animator animator)) {
                    animator.SetTrigger("Finished");
                    // if (isStage) StartCoroutine(FadeIn());
                }
                yield break;
            }
        }
    }

    IEnumerator FadeIn() {
        MusicPlayer.player.Play(MusicPlayer.player.GetStageAudio());
        while (MusicPlayer.player.GetVolume() < volume) {
            yield return new WaitForEndOfFrame();
            MusicPlayer.player.ChangeVolume(MusicPlayer.player.GetVolume() + (volume / 60.0f));
        }
    }

    IEnumerator FadeOut() {
        while (MusicPlayer.player.GetVolume() > 0) {
            yield return new WaitForEndOfFrame();
            MusicPlayer.player.ChangeVolume(MusicPlayer.player.GetVolume() - (volume / 60.0f));
        }
        Destroy(MusicPlayer.player);
    }
}
