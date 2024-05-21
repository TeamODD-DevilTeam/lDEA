using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryManager : StoryParser {
    [Serializable] public struct ChatBox {
        public Image chatbox;
        public TMP_Text scriptObj;
    }

    [Tooltip("이 스테이지의 값입니다.")]
    [SerializeField] int stageNum = 0;

    [Tooltip("알파 대사창입니다.")]
    [SerializeField] ChatBox alpha;

    [Tooltip("베타 대사창입니다.")]
    [SerializeField] ChatBox beta;

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
        
    }

    void PrintText() {
        // 현재 발화자를 감지합니다.

        // 대사 출력을 시작합니다.
        // coroutine = StartCoroutine(PrintText(story[position++].script));
    }

    IEnumerator PrintText(TMP_Text text, string script) {
        isPrinting = true; // 출력 중임을 알립니다.
        for (int i = 1; i <= script.Length; i++) { // 대사의 글자 수만큼 반복합니다.
            text.text = script.Substring(0, i); // 대사를 한 글자씩 나타나게끔 출력합니다.
            yield return new WaitForSeconds(0.1f); // 0.1초만큼 기다렸다가 반복문을 실행합니다. 코루틴문에서 필수적으로 들어가야하는 구문입니다.
        }
        isPrinting = false; // 출력이 끝났음을 알립니다.
    }
}
