using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField] List<string> guides = new List<string>();
    public static LoadingManager instance;

    void Start() {
        instance = this;
    }
}
