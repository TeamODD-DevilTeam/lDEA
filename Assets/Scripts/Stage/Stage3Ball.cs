using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Ball : MonoBehaviour {
    bool playEffect = false;

    void Update() {
        if (playEffect) {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(3.14f, -4.25f), 1.5f * Time.deltaTime);
            StartCoroutine(effectRemove());
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.TryGetComponent(out Spring spring)) {
            if (spring.GetDirection() == Spring.Direction.RIGHT) playEffect = true;
        }
    }

    IEnumerator effectRemove() {
        yield return new WaitForSeconds(3.5f);
        playEffect = false;
    }

    public bool GetPlayEffect() { return playEffect; }
}
