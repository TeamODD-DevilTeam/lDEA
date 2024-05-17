using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Unity.VisualScripting;

public class Title : MonoBehaviour {
    [SerializeField] Transform obj;
    // Start is called before the first frame update
    void Start() {
        obj.DOLocalMoveY(260.0f, 1.2f).SetEase(Ease.OutExpo);
        obj.DOScale(1.2f, 2.0f).SetEase(Ease.InBounce).SetLoops(-1, LoopType.Yoyo);
    }
}
