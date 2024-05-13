using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Credit : MonoBehaviour
{
    public RectTransform ins_traTitle = null;
    [Header("이동 속도")]
    [SerializeField]
    private int ins_nMoveSpeed = 150;
    [Header("이동 방향")]
    [SerializeField]
    private bool ins_bTop = true;

    //
    private RectTransform _rtaBg;
    private Vector2 _vStartPos;
    private Vector2 _vDirection = Vector2.up;
    private float _fEndPosY;

    private void Start()
    {
        _rtaBg = transform.GetComponent<RectTransform>();

        //ins_traTitle 가변 사이즈일 수 있기 때문에.
        LayoutRebuilder.ForceRebuildLayoutImmediate(ins_traTitle);
        float fTexthalf = ins_traTitle.rect.height / 2 + (_rtaBg.rect.height / 2);
        _fEndPosY = ins_traTitle.anchoredPosition.y;

        if (ins_bTop)
        {
            _vDirection = Vector2.up;
            _fEndPosY += fTexthalf;
        }
        else
        {
            _vDirection = Vector2.down;
            _fEndPosY -= fTexthalf;
        }
        _vStartPos = new Vector2(-_fEndPosY, ins_traTitle.anchoredPosition.y);
        ins_traTitle.anchoredPosition = _vStartPos;

        StartCoroutine(CorMoveText());
    }
    private IEnumerator CorMoveText()
    {
        while (true)
        {
            ins_traTitle.Translate(_vDirection * ins_nMoveSpeed * Time.unscaledDeltaTime);
            if (IsEndPos())
            {
                ins_traTitle.anchoredPosition = _vStartPos;
            }
            yield return null;
        }
    }

    private bool IsEndPos()
    {
        if (ins_bTop)
            return _fEndPosY < ins_traTitle.anchoredPosition.y;
        else
            return _fEndPosY > ins_traTitle.anchoredPosition.y;
    }

    
}
