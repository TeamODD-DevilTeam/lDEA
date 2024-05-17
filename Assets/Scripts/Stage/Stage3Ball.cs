using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Ball : MonoBehaviour {
    int springCount = 0;

    [Tooltip("충돌을 감지할 오브젝트입니다.")]
    [SerializeField] GameObject playerA, playerB;
    public float maxSpeed = 1.0f;
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent(out Spring spring)) {
            springCount = (springCount < 3) ? springCount + 1 : 1;
        }
    }

    public int GetSpringCount() { return springCount; }
}
