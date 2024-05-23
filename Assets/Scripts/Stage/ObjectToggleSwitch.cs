using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Tilemaps;

public class ObjectToggleSwitch : MonoBehaviour, ISwitch {
    [Serializable] struct Targets {
        public GameObject target; // 토글할 오브젝트
        public float moveTo; // 오브젝트가 움직일 위치
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
                float endValue = item.active ? 1f : 0f;
                item.target.transform.DOLocalMoveX(item.moveTo, 0.2f);
                StartCoroutine(AfterEffect(item, 0.2f));
            }
        }
    }

    IEnumerator AfterEffect(Targets item, float time) {
        yield return new WaitForSeconds(time);
        item.target.SetActive(item.active);
    }
}
