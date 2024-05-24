using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Counter2 : MonoBehaviour {
    [SerializeField] GameObject[] gates;
    [SerializeField] float moveTo;

    [SerializeField] int targetCount;
    int count = 0;
    public void IncreseCount() { 
        count++; 
        if (count == targetCount) {
            foreach (GameObject gate in gates) {
                gate.transform.DOLocalMoveX(moveTo, 0.2f);
                StartCoroutine(AfterEffect(gate, 0.2f));
            }
        }
    }

    IEnumerator AfterEffect(GameObject item, float time) {
        yield return new WaitForSeconds(time);
        item.SetActive(true);
    }
}
