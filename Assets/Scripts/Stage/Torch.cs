using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Block {
    [Tooltip("이 오브젝트의 애니메이터입니다.")]
    [SerializeField] Animator animator;
    [SerializeField] Counter counter;
    
    bool isActive = false; // 횃불의 상태를 저장하는 변수입니다.

    // 횃불이 비활성화된 상태라면 활성화합니다.
    public void Active() {
        if (!isActive) {
            animator.SetBool("isFire", true);
            isActive = true;
            counter.IncreseCount();
        }
    }

    // 횃불이 현재 활성화된 상태인지 확인합니다.
    public bool GetActive() { return isActive; }
}
