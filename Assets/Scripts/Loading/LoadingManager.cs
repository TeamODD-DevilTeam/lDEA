using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadingManager : MonoBehaviour {
    [SerializeField] Animator animator;
    [SerializeField] List<string> guides = new List<string>();
    [SerializeField] TMP_Text guide_text;
    public static LoadingManager instance;

    void Start() {
        instance = this;
        guide_text.text = guides[Random.Range(0, guides.Count - 1)];
    }
}
