using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    [Tooltip("바닥에 닿은 상태를 전달할 Player 객체입니다.")]
    [SerializeField] Player player;
    [Tooltip("점프 가능 여부를 확인하기 위한 바닥 오브젝트의 태그 이름입니다.")]
    [SerializeField] LayerMask groundLayer;
    
    void Update() {
        CheckGround();
    }

    void CheckGround() {
        Vector3 pos = transform.position;
        pos.x -= 0.5f;
        pos.y -= 0.5f;
        for (int i = 0; i < 3; i++) {
            RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(pos.x + (0.5f * i), pos.y), Vector2.down, 0.2f, groundLayer);
            if (hits.Length == 0) {}
            else {
                player.SetGrounded(true);
                break;
            }
        }
    }
}
