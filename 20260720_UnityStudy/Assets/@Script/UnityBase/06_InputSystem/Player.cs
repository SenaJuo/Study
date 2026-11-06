using System;
using UnityEngine;
namespace PlayerInputSystem
{ 
    public class Player : MonoBehaviour
    {
        /*dd
        1. WASD입력을 받으면, 플레이어의 위치를 옮기는 기능
        2. GetAxis를 가지고 플레이의 위치를 옮기는 기능
        3. 마우스 입력을 받아서, 플레이어의 회전값을 조정
         */
        [SerializeField] private float moveSpeed = 10f;
        
        private float currentPitch = 0f;
        [SerializeField] private float sensitivity = 2f;

        private Transform cameraTransform = null;
        private void Awake()
        {
            cameraTransform = GetComponentInChildren<Camera>().GetComponent<Transform>();
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))LockCursor();
            
            if(Input.GetKeyDown(KeyCode.Escape))UnLockCursor();
         //   MoveWithKey();
            MoveWithAxis();
            RotateMove();
        }
        //키 입력을 받아서, 플레이어를 움직이는 함수
        private void MoveWithKey()
        {
            //플레이어를 움직인다고 생각해보면 Transform -> position 조정
            //Vector3 연산을 해줘야 함
            //Vector3 direction = new Vector3(0f, 0f, 0f);

            //위랑 동일
            Vector3 direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                //direction += new Vector3(0f, 0f, 1f); //<<월드기준
                direction += transform.forward;//<<내 기준
            }
            if (Input.GetKey(KeyCode.S))
            {
                //direction -= new Vector3(0f, 0f, 1f); //<<월드기준
                direction -= transform.forward;
            }
            if (Input.GetKey(KeyCode.D))
            {
                //direction += new Vector3(1f, 0f, 0f);
                direction += transform.right;
            }
            if (Input.GetKey(KeyCode.A))
            {
                //direction -= new Vector3(1f, 0f, 0f);
                direction -= transform.right;
            }

            Vector3 normalizedDirection = direction.normalized;
            //내 현재 위치에서, 키 입력에 따라 계산된 direction만큼 더해주면 됨
            transform.position += normalizedDirection * Time.deltaTime * moveSpeed;
        }
        private void MoveWithAxis()
        {
            float horizontal = Input.GetAxisRaw("Horizontal"); //수평
            float vertical = Input.GetAxisRaw("Vertical"); //수직

            Vector3 direction = new Vector3(horizontal, 0f, vertical);

            Vector3 normalizedDirection = direction.normalized;

            //월드 기준으로 움직이면 내가 바라보는 방향이 아닌
            //월드기준의 Z방향으로 움직이기 때문에
            //바라보는 방향과 움직이는 방향이 달라짐
            //그래서 월드기준의 벡터를 내 기준의 앞쪽 방향으로 바꿔주는 연산이 필요함
            //그걸 해주는게 TransformDirection이라는 함수임
            Vector3 moveDirection = transform.TransformDirection(normalizedDirection);

            transform.position += moveDirection * Time.deltaTime * moveSpeed;
        }

        private void RotateMove()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            currentPitch -= mouseY * sensitivity;

            //지금 문제는 currentPtich를 계속 더하게 되면
            //카메라가 360도 회전되는게 문제임
            //그래서 currentPitch의 값을 범위로 제한해야 함
            //Mathf.Clamp(제한할 변수, 최소, 최대)
            currentPitch = Mathf.Clamp(currentPitch, -90f, 90f);
            
            //              ↓지금 본인이 가지고 있는 회전값
            cameraTransform.localEulerAngles = new Vector3(currentPitch, 0f, 0f);

            float playerRotation = mouseX * sensitivity;

            transform.Rotate(0f, playerRotation, 0f);
        }

        private void LockCursor()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void UnLockCursor()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}