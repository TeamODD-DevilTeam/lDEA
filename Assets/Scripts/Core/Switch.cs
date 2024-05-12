using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 코드를 기반으로 스위치 코드를 변형하여 작성하시면 됩니다.
public class Switch : MonoBehaviour {
    [Tooltip("발사체 오브젝트의 태그명을 지정하는데, 그 태그명이 변경되었을 때에만 사용하셔야 합니다. 기본값은 Bullet입니다.")]
    [SerializeField] string bulletTagName = "Bullet";
    bool isTriggered = false; // 스위치가 이미 작동된 상태인지 확인
    // 플레이어와 충돌했을 때 스위치를 작동시킴
    void OnTriggerEnter2D(Collider2D collider) {
        // 만약 플레이어와 충돌했다면
        if ((collider.gameObject.tag == "Player" || collider.gameObject.tag == bulletTagName) 
        && !isTriggered) {
            isTriggered = true; // 스위치가 작동되었음을 표시
            Debug.Log("스위치 작동됨"); // 정상 작동 확인을 위한 코드. 삭제 필요함
        }
    }
}
