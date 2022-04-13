using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTest : MonoBehaviour
{
    [Header("Input KeyCodes")] [SerializeField]
    private KeyCode keyCodeRun = KeyCode.LeftShift; // 달리기 키
    [SerializeField] private KeyCode keyCodeJump = KeyCode.Space; // 점프 키
    
    private RotateToMouse rotateToMouse; // 마우스 이동으로 카메라 회전
    private MovementCharacterController movement; // 키보드 입력으로 플레이어 이동, 점프
    private Status status; // 이동속도 등의 플레이어 정보
    
    private void Awake()
    {
        // 마우스 커서를 보이지 않게 설정하고, 현재 위치에 고정시킨다.
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementCharacterController>();
        status = GetComponent<Status>();
    }
    
    private void Update()
    {
        UpdateRotate();
        UpdateMove();
        UpdateJump();
    }
    
    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, mouseY);
    }

    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // 이동중일 때 (걷기 or 뛰기)
        if (x != 0 || z != 0)
        {
            bool isRun = false;

            movement.MoveSpeed = isRun == true ? status.RunSpeed : status.WalkSpeed;
        }
        // 제자리에 멈춰있을 때
        else
        {
            movement.MoveSpeed = 0;
        }

        movement.MoveTo(new Vector3(x, 0, z));
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(keyCodeJump))
        {
            movement.Jump();
        }
    }
}
