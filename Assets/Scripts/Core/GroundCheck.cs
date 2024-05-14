using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    [Tooltip("바닥에 닿은 상태를 전달할 Player 객체입니다.")]
    [SerializeField] Player player;

    [Tooltip("점프 가능 여부를 확인하기 위한 바닥 오브젝트의 태그 이름입니다.")]
    [SerializeField] string groundTagName = "Ground";

    // 점프가 가능한 상태인지 확인하기 위한 코드입니다.
    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision.gameObject.tag);
        // 바닥과의 충돌 감지로 점프 가능한 상태인지 확인
        if (collision.gameObject.tag == groundTagName || collision.gameObject.tag == "Player") {
            player.SetGrounded(true); // 전달받은 Player 객체의 isGrounded값을 true로 설정합니다.
        }
    }
}
