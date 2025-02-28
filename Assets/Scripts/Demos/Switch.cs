using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 코드를 기반으로 스위치 코드를 변형하여 작성하시면 됩니다.
// 기본적인 구조는 이 코드를 기반으로 해야합니다.
public class Switch : MonoBehaviour, ISwitch {
    bool isTriggered = false; // 스위치가 활성화되었는지 확인하는 코드입니다.
    [SerializeField] Animator animator;
    [SerializeField] Transform[] gates;
    public void Action() {
        // 여기서 스위치를 눌렀을 때 어떻게 작동할지 지정하시면 됩니다.
        // 이 함수는 필수로 작성하셔야 합니다.
        if (!isTriggered) { // 만약 스위치가 작동되지 않았다면
            if (animator != null) animator.SetTrigger("Toggle");
            isTriggered = true; // 스위치가 이미 작동되었으므로 다시 작동하지 않도록 합니다.
            foreach (Transform gate in gates) {
                Destroy(gate.gameObject);
            }
        }
    }
}

