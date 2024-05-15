using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour {
    [Serializable] enum Direction { UP, DOWN, LEFT, RIGHT }
    [Tooltip("스프링이 튕길 방향을 지정합니다.")]
    [SerializeField] Direction direction;
    [Tooltip("스프링이 튕기는 힘을 지정합니다.")]
    [SerializeField] float power = 24.0f;
    [Tooltip("튐기기 가능 여부를 확인하기 위한 플레이어 오브젝트의 태그 이름입니다.")]
    [SerializeField] LayerMask playerLayer;

    void OnCollisionEnter2D(Collision2D collision) {
        Vector3 pos = transform.position; // 플레이어의 위치를 가져옵니다.
        pos.x -= 0.5f; // Ray의 시작좌표를 설정합니다.
        pos.y += 0.5f;
        for (int i = 0; i < 6; i++) { // 플레이어의 맨 앞, 중앙, 맨 뒤로 x좌표를 지정합니다.
            RaycastHit2D playerCheck = Physics2D.Raycast(new Vector2(pos.x + (0.25f * i), pos.y), GetVector(direction), 0.2f, playerLayer);
            if (playerCheck.collider != null) {
                if (playerCheck.collider.gameObject.TryGetComponent(out Rigidbody2D component)) {
                    switch (direction) {
                        case Direction.UP:
                            component.velocity = new Vector2(component.velocity.x, power);
                            break;
                        case Direction.DOWN:
                            component.velocity = new Vector2(component.velocity.x, -power);
                            break;
                        case Direction.LEFT:
                            component.velocity = new Vector2(-power, component.velocity.y);
                            break;
                        case Direction.RIGHT:
                            component.velocity = new Vector2(power, component.velocity.y);
                            break;
                    }
                }
                break;
            }
        }
    }

    Vector2 GetVector(Direction direction) {
        Vector2 ret = Vector2.zero;
        switch (direction) {
            case Direction.UP:
                ret = Vector2.up;
                break;
            case Direction.DOWN:
                ret = Vector2.down;
                break;
            case Direction.LEFT:
                ret = Vector2.left;
                break;
            case Direction.RIGHT:
                ret = Vector2.right;
                break;
        }
        return ret;
    }
}