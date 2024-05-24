using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryParser : MonoBehaviour {
    public struct Story {
        public string name;
        public string script;
        public string image;
    }

    [Tooltip("캐릭터 스프라이트 입니다.")]
    [SerializeField] Sprite[] alpha, beta;

    [Tooltip("대사 파일입니다. 튜토리얼부터 차례로 스테이지 1~5입니다.")]
    [SerializeField] TextAsset[] textAsset;

    protected List<Story> ParseStory(int stageNum) {
        List<Story> story = new List<Story>();

        string[] datas = textAsset[stageNum].text.Split(new char[] { '\n' }); // 한 줄씩 배열로 저장합니다.
        foreach (string data in datas) {
            // csv 파일은 쉼표로 구분하기에 한 줄마다 쉼표를 기준으로 잘라 배열로 저장합니다.
            string[] lines = data.Split(new char[] { ',' }); 
            // 대사에 쉼표를 출력하기 위해 입력한 '-'를 모두 ','로 바꿔준 뒤 저장합니다.
            story.Add(new Story { name = lines[0], script = lines[1].Replace('-', ','), image = lines[2] });
        }
        return story;
    }

    protected Sprite GetSprite(string image) {
        Sprite sprite = alpha[0];
        switch (image.Trim()) {
            case "a0":
                sprite = alpha[0];
                break;
            case "a1":
                sprite = alpha[1];
                break;
            case "a2":
                sprite = alpha[2];
                break;
            case "b0":
                sprite = beta[0];
                break;
            case "b1":
                sprite = beta[1];
                break;
            case "b2":
                sprite = beta[2];
                break;
        }
        Debug.Log(sprite.name);
        return sprite;
    }
}
