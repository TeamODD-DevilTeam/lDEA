using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5Ball : MonoBehaviour {
    [SerializeField] GameObject gate;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject == gate) {
            gate.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
