using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecreditManager : MonoBehaviour {
    [SerializeField] AudioSource audioSource;
    public void PlaySFX(AudioClip audioClip) {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
