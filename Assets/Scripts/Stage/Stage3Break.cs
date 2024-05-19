using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Break : MonoBehaviour {
    [SerializeField] GameObject ball;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject == ball && ball.TryGetComponent(out Stage3Ball component)) {
            if (component.GetPlayEffect()) gameObject.SetActive(false);
            else ball.transform.position = new Vector2(-2.55f, -4.0f);
        }
    }
}
