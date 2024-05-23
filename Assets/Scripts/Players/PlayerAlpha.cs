using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAlpha : Player {
    Vector2 pos;
    // 플레이어가 공격 키를 눌렀을 때를 감지합니다. 알파와 베타의 공격은 서로 다른 공격이기에 Player 클래스를 상속받는 자식 클래스에 작성하였습니다.
    public void OnAttack(InputAction.CallbackContext value) {
        if (chatCanvas.gameObject.activeSelf) return;
        if (!value.started) return;
        // 가로가 2, 세로가 0인 사각형 범위 내의 콜라이더를 소유하고 있는 오브젝트를 확인합니다.
        pos = transform.position;
        if (isLeft) pos.x -= 0.5f;
        else pos.x += 0.5f;
        Collider2D[] colliders = Physics2D.OverlapBoxAll(pos, new Vector2(0.5f, 1), 1.5f);
        foreach (Collider2D collider in colliders) {
            // 강공격으로 파괴 가능한 오브젝트인지 확인합니다. 만약 파괴 가능한 오브젝트라면 파괴합니다.
            if (collider != null && collider.gameObject.TryGetComponent(out Block component)) { 
                switch (component.GetBlockType()) {
                    case BlockType.Grass:
                        if (elementType == ElementType.Fire) Destroy(collider.gameObject);
                        break;
                    case BlockType.Flowerpot:
                        if (elementType == ElementType.Grass) ((Flowerpot)component).Active();
                        break;
                    case BlockType.Normal:
                        ((Desk)component).DestroyObj();
                        break;
                    case BlockType.Agate:
                        ((Block4stage)component).DestroyGate();
                        break;          
                }
            }
        }
    }


    // interface
}
