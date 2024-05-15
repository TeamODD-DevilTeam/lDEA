using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    [Tooltip("바닥에 닿은 상태를 전달할 Player 객체입니다.")]
    [SerializeField] Player player;
    [Tooltip("점프 가능 여부를 확인하기 위한 바닥 오브젝트의 태그 이름입니다.")]
    [SerializeField] LayerMask groundLayer;
    [Tooltip("점프 가능 여부를 확인하기 위한 플레이어 오브젝트의 태그 이름입니다.")]
    [SerializeField] LayerMask playerLayer;
    Vector3 pos; // 플레이어의 위치를 저장합니다.
    
    void Update() {
        CheckGround(); // 바닥을 확인합니다.
    }

    void CheckGround() {
        pos = transform.position; // 플레이어의 위치를 가져옵니다.
        pos.x -= 0.5f; // Ray의 시작좌표를 설정합니다.
        pos.y -= 0.5f;
        for (int i = 0; i < 3; i++) { // 플레이어의 맨 앞, 중앙, 맨 뒤로 x좌표를 지정합니다.
            // 현재 플레이어를 밟은 상태인지 확인합니다.
            RaycastHit2D playerCheck = Physics2D.Raycast(new Vector2(pos.x + (0.5f * i), pos.y), Vector2.down, 0.2f, playerLayer);
            if (playerCheck.collider != null && playerCheck.collider.gameObject != player.gameObject) {
                player.SetGrounded(true);
                break;
            }

            RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(pos.x + (0.5f * i), pos.y), Vector2.down, 0.2f, groundLayer); // 플레이어의 아래쪽으로 가상의 Ray를 발사해 바닥이 존재하는지 확인합니다.
            if (hits.Length != 0) { // 조건에 만족하는 오브젝트 수가 0 이상인 경우 바닥에 닿은 것으로 판정합니다.
                player.SetGrounded(true);
                break;
            }
        }
    }
}
