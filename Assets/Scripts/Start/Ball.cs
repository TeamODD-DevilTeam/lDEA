using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D Ball collision) {
        // ball과 충돌했는지 확인합니다.
        if (collision.gameObject.TryGetComponent(out  component)) {
            component.Action(); // 스위치와 충돌한 경우 스위치 객체의 Action() 함수를 호출합니다.
        }
    }
}
