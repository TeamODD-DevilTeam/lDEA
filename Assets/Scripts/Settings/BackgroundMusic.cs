using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : SettingsManager {
    [Tooltip("볼륨값을 표기할 텍스트 오브젝트입니다.")]
    [SerializeField] TMP_Text volumeText;
    [Tooltip("볼륨값을 조절할 슬라이더입니다.")]
    [SerializeField] Slider slider;
    [Tooltip("설정 화면 테스트를 위한 MusicPlayer 오브젝트입니다.")]
    [SerializeField] GameObject musicPlayer;

    void Start() {
        slider.value = MusicPlayer.player.GetVolume();
        volumeText.text = ((int)(slider.value * 100)).ToString() + "%";
    }

    public void OnValueChanged() {
        MusicPlayer.player.ChangeVolume(slider.value);
        volumeText.text = ((int)(slider.value * 100)).ToString() + "%";
        SetVolume(slider.value); 
    }
}
