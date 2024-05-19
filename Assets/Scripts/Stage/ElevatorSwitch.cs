using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElevatorSwitch : MonoBehaviour, ISwitch {
    bool isTriggered = false;
    [SerializeField] Animator animator;
    [SerializeField] GameObject elevator;
    
    public void Action() {
        if (!isTriggered) { // 만약 스위치가 작동되지 않았다면
            if (animator != null) animator.SetTrigger("Toggle");
            if (elevator.TryGetComponent(out Elevator component)) component.StartUpSwitch();
            isTriggered = true;
        }
    }
}