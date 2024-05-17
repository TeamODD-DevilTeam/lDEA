using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Block4stage : Block
{
    [SerializeField] GameObject gate;

    public void DestroyGate()
    {
        gate.SetActive(false);
        gameObject.SetActive(false);
    }
}
