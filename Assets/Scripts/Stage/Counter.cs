using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour {
    [SerializeField] GameObject[] gates;

    [SerializeField] int targetCount;
    int count = 0;
    public void IncreseCount() { 
        count++; 
        if (count == targetCount) {
            foreach (GameObject gate in gates) {
                gate.SetActive(false);
            }
        }
    }
}
