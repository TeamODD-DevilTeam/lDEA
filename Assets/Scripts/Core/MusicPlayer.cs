using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    [Serializable] class Musics {
        public AudioClip defaultBgm;
        public AudioClip stageBgm;
    }

    [SerializeField] AudioSource audioSource;
    [SerializeField] SettingsManager settings;
    [SerializeField] Musics musics;

    public static MusicPlayer player;

    void Start() {
        if (player != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        player = this;

        ChangeVolume(settings.GetVolume());
        Play(musics.defaultBgm);
    }

    public void Play(AudioClip audio) {
        if (audioSource.isPlaying) audioSource.Stop();
        audioSource.clip = audio;
        audioSource.Play();
    }

    public void Pause() {
        audioSource.Pause();
    }

    public void Stop() {
        audioSource.Stop();
    }

    public void ChangeVolume(float volume) {
        audioSource.volume = volume;
    }
    
    public float GetVolume() {
        return audioSource.volume;
    }

    public AudioClip GetStageAudio() {
        return musics.stageBgm;
    }
}
