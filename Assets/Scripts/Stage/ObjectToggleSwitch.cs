using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToggleSwitch : MonoBehaviour, ISwitch {
    [Serializable] struct Targets {
        public GameObject target; // 토글할 오브젝트
        public bool active; // 스위치가 작동되었을 때의 오브젝트의 활성화 상태
    }

    [Tooltip("이 오브젝트의 애니메이터입니다.")]
    [SerializeField] Animator animator;
    [Tooltip("활성/비활성화할 오브젝트 목록입니다. active 값에 따라 오브젝트의 활성/비활성 상태가 결정됩니다.")]
    [SerializeField] List<Targets> targets;

    bool toggle = false;
    public void Action() {
        if (!toggle) {
            animator.SetTrigger("Toggle");
            toggle = true;
            foreach (Targets item in targets) {
                item.target.SetActive(item.active);
            }
        }
    }
}
