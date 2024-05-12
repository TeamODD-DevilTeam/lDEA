using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlpha : Player {
    [Tooltip("파괴 가능한 장애물의 태그명이며, 그 태그명이 변경되었을 때에만 사용하셔야 합니다. 기본값은 Block입니다.")]
    [SerializeField] string blockTagName = "Block";

    // 플레이어가 공격 키를 눌렀을 때를 감지합니다. 알파와 베타의 공격은 서로 다른 공격이기에 Player 클래스를 상속받는 자식 클래스에 작성하였습니다.
    void OnAttack() {
        // 반지름이 1인 원 범위 내의 충돌 가능한 오브젝트를 확인합니다.
        Collider2D collider = Physics2D.OverlapCircle(transform.position, 1);
        if (collider != null && collider.tag == "Block") {
            Destroy(collider.gameObject); // 만약 파괴 가능한 장애물인 경우 파괴합니다.
        }
    }
}
