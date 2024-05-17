using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour {
    [Tooltip("충돌을 감지할 오브젝트입니다.")]
    [SerializeField] GameObject playerA, playerB;
    [Tooltip("이 오브젝트의 Rigidbody2D입니다.")]
    [SerializeField] Rigidbody2D rb;
    [Tooltip("이 오브젝트의 collider2D입니다")]
    [SerializeField] Collider2D cd;
    bool isA = false;
    bool isB = false;
    public float maxSpeed = 1.0f;
    [SerializeField] LayerMask defaultLayer, SpecialLayer;
    
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
            cd.forceReceiveLayers = SpecialLayer;
        }
        else {
            cd.forceReceiveLayers = defaultLayer;
        }
    }

    private void FixedUpdate() {
        MoveBall();
    }
}
