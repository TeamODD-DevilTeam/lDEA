using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Desk : Block {
    [SerializeField] BoxCollider2D boxCollider;

    public void DestroyObj() {
        boxCollider.enabled = false;
        // rigidbody로 수류탄같은거 구현할 때 가운데에서 힘을 줘서 일정 범위 내의~
        // Rigidbody.AddExplosionForce
        transform.DOBlendableLocalMoveBy(SetRandomPosition(), 1.0f);
        transform.DOBlendableRotateBy(new Vector3(0, 0, Random.Range(-90, 90)), 1.0f);
        GetComponent<SpriteRenderer>().DOFade(0, 1.0f);
        StartCoroutine(DisableObj());
    }

    Vector3 SetRandomPosition() {
        return new Vector3(Random.Range(1f, 3f), Random.Range(3f, -3f), 0);
    }

    IEnumerator DisableObj() {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
