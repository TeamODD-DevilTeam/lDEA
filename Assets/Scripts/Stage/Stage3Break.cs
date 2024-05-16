using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Break : MonoBehaviour {
    [SerializeField] GameObject ball;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == ball) {
            gameObject.SetActive(false);
        }
    }
}
