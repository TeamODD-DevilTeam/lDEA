using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeta : Player {
    [Tooltip("생성할 발사체의 프리팹입니다.")]
    [SerializeField] GameObject bulletPrefab;
    [Tooltip("생성할 발사체의 초기 위치입니다.")]
    [SerializeField] GameObject spawnPoint;

    // 클래스 내부에서 사용하는 변수
    Vector3 pos; // 발사체가 생성될 위치를 지정하는 변수
    
    // 플레이어가 공격 키를 눌렀을 때를 감지합니다. 알파와 베타의 공격은 서로 다른 공격이기에 Player 클래스를 상속받는 자식 클래스에 작성하였습니다.
    void OnAttack() {
        // 좌 또는 우방향을 보고 있음에 따라 발사체가 생성되는 위치와 방향을 지정합니다.
        pos = transform.position; // 현재 위치를 먼저 가져옵니다.
        if (isLeft) {
            pos.x = transform.position.x - 0.55f; // 좌측을 보고 있는 경우 현위치의 왼쪽으로 지정
        }
        else {
            pos.x = transform.position.x + 0.55f; // 우측을 보고 있는 경우 현위치의 오른쪽으로 지정
        }
        spawnPoint.transform.position = pos; // 오브젝트의 위치를 위에서 지정된 값으로 지정합니다.

        // 오브젝트를 생성합니다.
        GameObject obj = Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.SetDirection(isLeft); // 오브젝트가 플레이어가 바라보는 방향으로 날아갑니다.
        bullet.SetElementType(elementType); // 오브젝트가 플레이어의 원소 속성으로 지정되어 날아갑니다.
    }

    public void SetElementType(ElementType elementType) { this.elementType = elementType; }
    public ElementType GetElementType() { return elementType; }
}
