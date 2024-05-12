using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [Tooltip("발사체의 속도를 지정합니다.")]
    [SerializeField] float speed = 10;
    Vector3 moveDirection;
    
    // 발사체가 날아갈 방향을 지정하는 함수입니다. 외부에서 접근할 수 있게해 오브젝트가 생성될 때 정해질 수 있도록 합니다.
    public void SetDirection(bool isLeft) {
        // 그런데 어째서인지 X값과 Y값이 뒤바뀌었는데 원인은 저도 잘 모르겠습니다.
        if (isLeft) moveDirection = new Vector3(0, 1, 0);
        else moveDirection = new Vector3(0, -1, 0);
    }

    // 발사체가 날아가기 위해 매 프레임 공백 시마다 위치를 변경합니다.
    void FixedUpdate() {
        transform.Translate(moveDirection * Time.deltaTime * speed);
    }

    // 만약 어딘가에 닿았을 경우 오브젝트를 파괴합니다. 단, 오브젝트가 어딘가에 닿지 않았을 경우 파괴되지 않습니다.
    void OnCollisionEnter2D(Collision2D collision) { Destroy(gameObject); }
    void OnTriggerEnter2D(Collider2D collision) { Destroy(gameObject); }
}
