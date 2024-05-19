using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : Block {
    [Tooltip("이 오브젝트의 스프라이트 렌더러입니다.")]
    [SerializeField] SpriteRenderer sprite;
    [Tooltip("기본 횃불 스프라이트입니다.")]
    [SerializeField] Sprite normalTorch;
    [Tooltip("활성화된 횃불 스프라이트입니다.")]
    [SerializeField] Sprite activedTorch;
    
    bool isActive = false; // 횃불의 상태를 저장하는 변수입니다.

    // 횃불이 비활성화된 상태라면 활성화합니다.
    public void Active() {
        if (!isActive) {
            sprite.sprite = activedTorch;
            isActive = true;
        }
    }

    // 횃불이 현재 활성화된 상태인지 확인합니다.
    public bool GetActive() { return isActive; }
}
