using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    [SerializeField] Transform alpha, beta;
    [SerializeField] float smoothTime = 0.2f;
    [SerializeField] bool isMove = false;
    Vector3 velocity = Vector3.zero;
    void Update() {
        if (!isMove) return;
        Vector3 pos = (alpha.position + beta.position) / 2;
        pos.z = -10;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime);
    }
}
