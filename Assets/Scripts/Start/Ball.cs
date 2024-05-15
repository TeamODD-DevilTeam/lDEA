using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour {
    [Tooltip("충돌을 감지할 오브젝트입니다.")]
    [SerializeField] GameObject playerA, playerB;
    [Tooltip("이 오브젝트의 Rigidbody2D입니다.")]
    [SerializeField] Rigidbody2D rb;
    bool isA = false;
    bool isB = false;
    public float maxSpeed = 1.0f;
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == playerA) isA = true;
        else if (collision.gameObject == playerB) isB = true;
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject == playerA) isA = false;
        else if (collision.gameObject == playerB) isB = false;
    }

    void MoveBall() {
        if (isA && isB) {
            rb.constraints = RigidbodyConstraints2D.None;
        }
        else {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            rb.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate() {
        MoveBall();
    }
}
