using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialElement : MonoBehaviour {
    [SerializeField] ElementType elementType;
    public ElementType GetElementType() { return elementType; }
}
