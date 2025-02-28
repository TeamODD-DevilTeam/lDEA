using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어에 공통적으로 사용되는 코드입니다.
/// </summary>
public class Player : MonoBehaviour
{
    // 하이어라키 창에서 지정해야하는 변수 - 필수로 지정해야 함
    [Tooltip("이 오브젝트의 Animator 컴포넌트를 참조합니다.")]
    [SerializeField] protected Animator animator;
    [Tooltip("이 오브젝트의 Rigidbody2D 컴포넌트를 참조합니다.")]
    [SerializeField] Rigidbody2D rigid;
    [Tooltip("플레이어의 움직임 속도를 지정합니다.")]
    [SerializeField] float moveSpeed = 10.0f;
    [Tooltip("플레이어의 점프 높이를 지정합니다.")]
    [SerializeField] float jumpPower = 15.0f;
    [Tooltip("플레이어의 방향을 지정합니다. 참일 경우 왼쪽을 바라봅니다.")]
    [SerializeField] protected bool isLeft = false;
    [Tooltip("움직이는 플랫폼에 지정된 레이어를 지정합니다.")]
    [SerializeField] LayerMask platformLayer;
    [Tooltip("점프 효과음을 재생할 컴포넌트입니다.")]
    [SerializeField] AudioSource jumpEffectPlayer;
    [Tooltip("점프 효과음입니다.")]
    [SerializeField] AudioClip audioClip;
    [Tooltip("채팅창 캔버스입니다.")]
    [SerializeField] protected Canvas chatCanvas;

    [SerializeField] protected GameObject fire, grass; // 5스테 현속성 표기용

    // 내부적으로 사용하는 변수
    GameObject contactPlatform; // 어떤 플랫폼 위에 올라왔는지 확인하기 위한 변수입니다.
    Vector3 platformDistance = Vector3.zero; // 플랫폼 위에 올라왔을 때 같이 움직이기 위한 변수입니다.
    Vector2 moveDirection; // 플레이어의 이동을 관리합니다.
    bool isGrounded = false; // 플레이어가 현재 바닥과 닿은 상태인지 확인합니다.
    bool isJumping = false; // 플레이어가 점프 중인 상태인지 확인합니다.
    // 자식 클래스에서도 사용하는 변수 (알파, 베타가 공통적으로 사용하는 변수)
    protected GameObject collisionBlock; // 플레이어 알파와 충돌한 파괴 가능한 블럭을 지정합니다.
    protected ElementType elementType = ElementType.None; // 플레이어의 공격 속성을 지정하는 변수입니다.
    protected bool isMoveable = true; // 문에 닿은 경우 이동을 정지하기 위해 사용하는 변수입니다.

    // 프레임 관련 이슈가 생길 수 있어 FixedUpdate를 사용했으나, 만약 여기서 프레임 끊김 현상이 생긴다면 Update 함수를 사용해야 합니다.
    // 매 프레임마다 Update - FixedUpdate가 순서대로 호출되는 것으로 알고 있습니다. (찾아봐야 함)
    void FixedUpdate() {
        if (!isJumping && platformDistance != Vector3.zero && contactPlatform != null) {
            transform.position = contactPlatform.transform.position - platformDistance;
        }
        // 플레이어를 좌우로 이동시킵니다. 만약 점프 중이라면 동시에 점프할 수 있게끔 합니다.
        if (moveDirection.x != 0) {
            rigid.AddForce(new Vector2((moveDirection.x * moveSpeed - rigid.velocity.x) * moveSpeed, 0f));
        } else if (isGrounded) {
            rigid.AddForce(new Vector2(-rigid.velocity.x * moveSpeed, 0f));
        }
        // 플레이어가 바닥 위에 있다면 점프를 합니다. 만약 이동 중이라면 동시에 움직일 수 있게끔 합니다.
        if (isJumping && isGrounded) {
            platformDistance = Vector3.zero;
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
            jumpEffectPlayer.clip = audioClip;
            jumpEffectPlayer.Play();
            isGrounded = false; // 이 코드가 한 번만 실행되게끔 합니다.
        }
        rigid.velocity = new Vector2(rigid.velocity.x, rigid.velocity.y);
    }

    // 키보드 입력을 받음 (좌우 이동)
    public void OnMove(InputAction.CallbackContext value) {
        if (chatCanvas.gameObject.activeSelf || !isMoveable) return;
        Vector2 input = value.ReadValue<Vector2>(); // 입력을 받아옵니다.
        if (input != null) { // 입력이 잘못되었을 수 있으므로, input을 확인합니다.
            if (animator != null) animator.SetBool("isMove", true); // 플레이어가 움직이는 애니메이션을 재생
            platformDistance = Vector3.zero; // 플랫폼 위에서 움직일 수 있도록 위치를 초기화합니다.
            moveDirection.x = input.x; // 움직일 X좌표를 입력받은 값으로 지정합니다. (SystemInput)
            if (moveDirection.x > 0) isLeft = false; // 만약 0보다 크면 우측으로 이동합니다.
            else if (moveDirection.x < 0) isLeft = true; // 0보다 작은 경우 좌측으로 이동합니다.
            gameObject.GetComponent<SpriteRenderer>().flipX = isLeft; // 플레이어가 보는 방향을 설정합니다.
            // 0인 경우 이전 상태(보고있는 방향)를 저장하기 위해 isLeft 변수를 조작하지 않습니다.
        }
        if (value.canceled && animator != null)
            animator.SetBool("isMove", false); // 플레이어가 움직이는 애니메이션을 중단
    }

    // 키보드 입력을 받음 (점프 토글)
    public void OnJump(InputAction.CallbackContext value) {
        if (chatCanvas.gameObject.activeSelf) return;
        if (value.started) {
            isJumping = true;
        } else if (value.canceled) isJumping = false;
    }

    // 플랫폼 등의 오브젝트와 충돌했을 때 감지하기 위한 코드입니다.
    void OnCollisionEnter2D(Collision2D collision) {
        Vector3 pos = transform.position; // 플레이어의 위치를 가져옵니다.
        pos.x -= 0.5f; // Ray의 시작좌표를 설정합니다.
        pos.y -= 0.5f;
        for (int i = 0; i < 3; i++) { // 플레이어의 맨 앞, 중앙, 맨 뒤로 x좌표를 지정합니다.
            RaycastHit2D platformCheck = Physics2D.Raycast(new Vector2(pos.x + (0.5f * i), pos.y), Vector2.down, 0.2f, platformLayer);
            if (platformCheck.collider != null) {
                contactPlatform = collision.gameObject;
                platformDistance = contactPlatform.transform.position - transform.position;
                break;
            }
        }
    }
    
    // 플랫폼 등의 오브젝트로부터 벗어났을 때 감지하기 위한 코드입니다.
    void OnCollisionExit2D(Collision2D collision) {
        Vector3 pos = transform.position; // 플레이어의 위치를 가져옵니다.
        pos.x -= 0.5f; // Ray의 시작좌표를 설정합니다.
        pos.y -= 0.5f;
        for (int i = 0; i < 3; i++) { // 플레이어의 맨 앞, 중앙, 맨 뒤로 x좌표를 지정합니다.
            RaycastHit2D platformCheck = Physics2D.Raycast(new Vector2(pos.x + (0.5f * i), pos.y), Vector2.down, 0.2f, platformLayer);
            if (platformCheck.collider != null) {
                platformDistance = Vector3.zero;
                contactPlatform = null;
            }
        }
    }

    // 스위치 등의 오브젝트와 충돌했을 때 감지하기 위한 코드입니다.
    void OnTriggerEnter2D(Collider2D collision) {
        // 스위치와 충돌했는지 확인합니다. 스위치 오브젝트가 Switch 클래스가 상속받는 ISwitch를 소유하고 있는지 확인합니다.
        if (collision.gameObject.TryGetComponent(out ISwitch component)) {
            component.Action(); // 스위치와 충돌한 경우 스위치 객체의 Action() 함수를 호출합니다.
        }
        if (collision.gameObject.TryGetComponent(out SpecialElement element)) {
            elementType = element.GetElementType();
            if (fire != null && grass != null) {
                switch (elementType) {
                    case ElementType.Fire:
                        fire.SetActive(true);
                        grass.SetActive(false);
                        break;
                    case ElementType.Grass:
                        fire.SetActive(false);
                        grass.SetActive(true);
                        break;
                }
            }
        }
        
    }

    // GroundCheck 클래스에서 호출할 바닥 상태 확인 함수입니다.
    public void SetGrounded(bool isGrounded) {
        // 전달받은 값으로 moveDirectionY값과 isGrounded값을 설정합니다.
        this.isGrounded = isGrounded;
    }

    public void SetMoveable(bool isMoveable) {
        this.isMoveable = isMoveable;
        if (!isMoveable) animator.SetBool("isMove", false);
    }

}
