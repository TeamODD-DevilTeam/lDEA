using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [Tooltip("발사체의 속도를 지정합니다.")]
    [SerializeField] float speed = 10;
    Vector3 moveDirection;
    ElementType elementType = ElementType.None;

    // 발사체의 속성을 지정합니다. 발사체가 속성을 가질 때에만 호출하여야 합니다.
    public void SetElementType(ElementType elementType) { this.elementType = elementType; }
    
    // 발사체가 날아갈 방향을 지정하는 함수입니다. 외부에서 접근할 수 있게해 오브젝트가 생성될 때 정해질 수 있도록 합니다.
    public void SetDirection(bool isLeft) {
        // 좌측일 땐 X좌표가 감소, 우측일 땐 X좌표값이 증가해야 하므로 아래와 같이 지정하였습니다.
        if (isLeft) moveDirection = new Vector3(-1, 0, 0);
        else moveDirection = new Vector3(1, 0, 0);
    }

    // 발사체가 날아가기 위해 매 프레임 공백 시마다 위치를 변경합니다.
    void FixedUpdate() {
        transform.Translate(moveDirection * Time.deltaTime * speed);
    }

    // 만약 어딘가에 닿았을 경우 오브젝트를 파괴합니다. 단, 오브젝트가 어딘가에 닿지 않았을 경우 파괴되지 않습니다.
    void OnTriggerEnter2D(Collider2D collision) { 
        // 만약 스위치에 닿았을 경우 스위치를 작동시킵니다.
        if (collision.gameObject.TryGetComponent(out ISwitch component)) {
            component.Action();
        } else if (collision.gameObject.TryGetComponent(out Block block) && 
            elementType == ElementType.Fire) {
            // 만약 발사체가 불속성일 때 잔디에 닿았을 경우 잔디를 파괴합니다.
            if (block.IsBlockType(BlockType.Grass)) Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
