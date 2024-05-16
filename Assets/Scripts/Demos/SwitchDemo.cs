using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDemo : MonoBehaviour, ISwitch
{
    bool isTriggered = false; // 스위치가 활성화되었는지 확인하는 코드입니다.
    [SerializeField] GameObject gate;
    public void Action()
    {
        // 여기서 스위치를 눌렀을 때 어떻게 작동할지 지정하시면 됩니다.
        // 이 함수는 필수로 작성하셔야 합니다.
        if (!isTriggered)
        { // 만약 스위치가 작동되지 않았다면
            isTriggered = true; // 스위치가 이미 작동되었으므로 다시 작동하지 않도록 합니다.
            gate.SetActive(true);
        }
    }
}
