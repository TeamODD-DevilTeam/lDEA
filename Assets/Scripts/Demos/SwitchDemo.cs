using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDemo : MonoBehaviour,ISwitch
{
    private bool isTriggered = false;
    public void Action()
    {
        if (!isTriggered)
        {
            Debug.Log("스위치 작동됨"); 
            isTriggered = true;
        }
    }
}
