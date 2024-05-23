using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    [SerializeField] Canvas clearCanvas;

    bool triggeredA = false, triggeredB = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent(out PlayerAlpha alpha)) {
            alpha.SetMoveable(false);
            alpha.gameObject.SetActive(false);
            triggeredA = true;
        } else if (other.TryGetComponent(out PlayerBeta beta)) {
            beta.SetMoveable(false);
            beta.gameObject.SetActive(false);
            triggeredB = true;
        }

        if (triggeredA && triggeredB) {
            clearCanvas.gameObject.SetActive(true);
        }
    }
}
