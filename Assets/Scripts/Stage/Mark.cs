using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : Block {
    [SerializeField] Counter counter;
    void OnTriggerEnter2D(Collider2D collision) { 
        if (collision.gameObject.TryGetComponent(out Bullet bullet)) {
            counter.IncreseCount();
            Destroy(bullet.gameObject);
            Destroy(gameObject);
        }
    }
}
