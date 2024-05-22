using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowerpot : Block {
    [Serializable] struct Targets {
        public GameObject target; // 토글할 오브젝트
        public bool active; // 스위치가 작동되었을 때의 오브젝트의 활성화 상태
    }

    [Tooltip("활성/비활성화할 오브젝트 목록입니다. active 값에 따라 오브젝트의 활성/비활성 상태가 결정됩니다.")]
    [SerializeField] List<Targets> targets;

    bool isActive = false; // 화분의 상태를 저장하는 변수입니다.

    // 횃불이 비활성화된 상태라면 활성화합니다.
    public void Active() {
        if (!isActive) {
            isActive = true;
            foreach (Targets target in targets) {
                target.target.SetActive(target.active);
            }
        }
    }
}
