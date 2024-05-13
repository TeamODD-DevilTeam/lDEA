using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAlpha : Player {
    // 플레이어가 공격 키를 눌렀을 때를 감지합니다. 알파와 베타의 공격은 서로 다른 공격이기에 Player 클래스를 상속받는 자식 클래스에 작성하였습니다.
    void OnAttack() {
        // 가로가 2, 세로가 0인 사각형 범위 내의 콜라이더를 소유하고 있는 오브젝트를 확인합니다.
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(2, 0), 1.5f);
        foreach (Collider2D collider in colliders) {
            // 강공격으로 파괴 가능한 오브젝트인지 확인합니다. 만약 파괴 가능한 오브젝트라면 파괴합니다.
            if (collider != null && collider.gameObject.TryGetComponent(out Block component)) { 
                if (component.IsBlockType(BlockType.Normal)) Destroy(collider.gameObject);
            }
        }
    }

    // interface
}
