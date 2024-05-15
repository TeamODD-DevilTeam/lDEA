using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    [Serializable] struct MovableArea {
        public Vector2 min, max;
    };

    [Tooltip("카메라의 기준점이 될 두 오브젝트의 위치입니다.")]
    [SerializeField] Transform alpha, beta;
    [Tooltip("카메라의 이동 속도를 지정합니다.")]
    [SerializeField] float smoothTime = 0.2f;
    [Tooltip("카메라가 최대로 움직일 수 있는 이동 영역을 지정합니다.")]
    [SerializeField] MovableArea movableArea = new MovableArea {
        min = new Vector2(-100f, -100f), max = new Vector2(100f, 100f)
    };
    [Tooltip("카메라 이동을 사용할 것인지 지정합니다.")]
    [SerializeField] bool isMove = false;
    Vector3 velocity = Vector3.zero; // 카메라의 이동에 필요한 변수입니다.
    Vector3 pos; // 카메라의 위치를 지정할 변수입니다.
    void Update() {
        if (!isMove) return;
        pos = (alpha.position + beta.position) / 2; // 이동할 위치를 두 오브젝트의 중앙으로 지정합니다.
        pos.z = -10; // 카메라의 Z값을 -10에 고정합니다.

        // 카메라의 위치가 movableArea 안인지 확인합니다.
        if (movableArea.min.x > pos.x) pos.x = movableArea.min.x;
        else if (movableArea.max.x < pos.x) pos.x = movableArea.max.x;
        if (movableArea.min.y > pos.y) pos.y = movableArea.min.y;
        else if (movableArea.max.y < pos.y) pos.y = movableArea.max.y;

        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime); // 카메라를 부드럽게 지정한 시간동안 지정한 위치로 이동시킵니다.
    }
}
