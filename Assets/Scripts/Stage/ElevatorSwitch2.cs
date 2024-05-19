using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElevatorSwitch2 : MonoBehaviour {
    bool isTriggered = false;
    [SerializeField] GameObject circle;
    [SerializeField] Animator animator;
    [SerializeField] GameObject elevator;
    
    void Action() {
        if (!isTriggered) { // 만약 스위치가 작동되지 않았다면
            if (animator != null) animator.SetTrigger("Toggle");
            if (elevator.TryGetComponent(out Elevator component)) component.StartUpDownSwitch();
            isTriggered = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject == circle) {
            Action();
        }
    }
}