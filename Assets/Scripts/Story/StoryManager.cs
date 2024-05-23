using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class StoryManager : StoryParser {
    [Tooltip("이 스테이지의 값입니다.")]
    [SerializeField] int stageNum = 0;

    [Tooltip("대사창입니다.")]
    [SerializeField] Image alphaImage, betaImage;

    [Tooltip("대사 출력창입니다.")]
    [SerializeField] TMP_Text nameObj, scriptObj;

    [Tooltip("대화창이 보여지는 캔버스입니다.")]
    [SerializeField] Canvas canvas;

    List<Story> story;
    int position = 0; // 현재 대사의 출력 위치입니다.
    bool isPrinting = false; // 현재 대사가 출력중인지 확인합니다.
    Coroutine coroutine; // 현재 대사를 출력하는 코루틴을 저장합니다.

    void Start() {
        story = ParseStory(stageNum);
        PrintText();
    }

    // Update is called once per frame
    void Update() {
        if (Input.anyKeyDown) { // 만약 아무 키나 눌렀을 때
            if (!isPrinting) { // 만약 출력 중이 아니라면
                if (position < story.Count) PrintText(); // 다음 대사가 있다면 출력합니다.
                else {
                    canvas.gameObject.SetActive(false);
                }
            } else { // 출력 중이라면
                StopCoroutine(coroutine); // 출력 중인 코루틴을 멈추고
                scriptObj.text = story[position - 1].script; // 대사는 한 번에 전부 보여줍니다.
                isPrinting = false; // 텍스트가 출력 중이 아님을 표시합니다.
            }
        }
    }

    void PrintText() {
        // 현재 발화자를 감지합니다.
        nameObj.text = story[position].name;
        if (story[position].image.IndexOf("b") != -1) {
            alphaImage.color = SetColor(160, 160, 160, 255);
            betaImage.color = SetColor(255, 255, 255, 255);
            betaImage.sprite = GetSprite(story[position].image);
        } else {
            alphaImage.color = SetColor(255, 255, 255, 255);
            betaImage.color = SetColor(160, 160, 160, 255);
            alphaImage.sprite = GetSprite(story[position].image);
        }

        // 대사 출력을 시작합니다.
        coroutine = StartCoroutine(PrintText(story[position].script));
        position++;
    }

    IEnumerator PrintText(string script) {
        isPrinting = true; // 출력 중임을 알립니다.
        for (int i = 1; i <= script.Length; i++) { // 대사의 글자 수만큼 반복합니다.
            scriptObj.text = script.Substring(0, i); // 대사를 한 글자씩 나타나게끔 출력합니다.
            yield return new WaitForSeconds(0.05f); // 0.05초만큼 기다렸다가 반복문을 실행합니다. 코루틴문에서 필수적으로 들어가야하는 구문입니다.
        }
        isPrinting = false; // 출력이 끝났음을 알립니다.
    }

    Color SetColor(float r, float g, float b, float a = 255) {
        return new Color(r/255f, g/255f, b/255f, a/255f);
    }
}
