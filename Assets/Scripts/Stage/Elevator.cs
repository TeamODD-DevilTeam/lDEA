using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Elevator : MonoBehaviour {
    bool stopUpDown = false;

    public void StartUpSwitch() {
        gameObject.transform.DOLocalMoveY(1.55f, 2.0f).SetEase(Ease.InOutSine);
    }

    public void StartUpDownSwitch() {
        StartCoroutine(UpDownSwitch());
    }

    IEnumerator UpDownSwitch() {
        while (!stopUpDown) {
            if (gameObject.transform.position.y == -3.3f) {
                gameObject.transform.DOLocalMoveY(1.55f, 2.0f).SetEase(Ease.InOutSine);
            } else {
                gameObject.transform.DOLocalMoveY(-3.3f, 2.0f).SetEase(Ease.InOutSine);
            }
            yield return new WaitForSeconds(2.0f);
        }
    }
}
