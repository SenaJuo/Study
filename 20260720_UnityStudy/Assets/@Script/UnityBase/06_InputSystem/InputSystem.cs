using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class InputSystem : MonoBehaviour
{
   
    //Update를 만들어서 입력이 들어오는지, 안들어오는지를 계속 확인할거임
    private void Update()
    {
        //지금 확인해볼거는 구버전의 InputSystem임
        //구버전의 InputSystem은 Update에서
        //매 프레임 체크하는 방식으로 작동함

        //신버전의 InputSysytem은 이벤트 형식으로 작동하고,
        //다양한 하드웨어에 대응하기 쉽도록 만들어져 있음

        //1. GetKeyDown() - 키보드의 특정 키를 눌렀을때, true를 반환하는 함수

        //Z키를 눌렀을때, 반응함
        if (Input.GetKeyDown(KeyCode.Z/*대소문자 구분*/))
        {
            Debug.Log("Z키 눌러짐");
        }

        //2. GetKey()
        //GetKeyDown()은 눌렀을떄, 한번만 입력이 감지 되는데
        //GetKey()를 쓰면, 누르고 있을때 동안, 계속 감지가 됨

        if (Input.GetKey(KeyCode.X))
        {
            Debug.Log("X키 눌러짐");
        }

        //3 GetKeyUp()
        //키를 눌렀다가 뗄떄, 입력이 감지됨

        if (Input.GetKeyUp(KeyCode.C))
        {
            Debug.Log("C 키를 누르다가 뗌");
        }

        //Mouse input
        //1. GetMouseButtonDown() <<마우스 버튼 눌렀을 때
        //함수의 인자로는 어떤 마우스 버튼을 눌렀는지를 넣어주면 됨
        // 0 : 마우스 좌클릭
        // 1 : 마우스 우클릭
        // 2 : 마우스 휠클릭

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("마우스 좌클릭!");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("마우스 우클릭!");
        }

        if (Input.GetMouseButtonDown(2))
        {
            Debug.Log("마우스 휠클릭!");
        }

        /*
        GetMouseButton()
        마우스 누르고 있을때 계속 입력 감지
        */

        if (Input.GetMouseButton(0))
        {
            Debug.Log("마우스 좌클릭 하는 중!");
        }

        if (Input.GetMouseButton(1))
        {
            Debug.Log("마우스 우클릭 하는 중!");
        }

        if (Input.GetMouseButton(2))
        {
            Debug.Log("마우스 휠클릭 하는 중!");
        }

        //Axis
        //마우스의 움직임 속도에 따라서 값이 바뀜


        //수평기준, 즉, x축 기준으로 값을 가져옴
        float moveX = Input.GetAxis("Mouse X");

        //수직기준, 즉, y축 기준으로 값을 가져옴
        float moveY = Input.GetAxis("Mouse Y");

        //마우스 휠 움직일때, 값을 가져옴
        float mouseScroll = Input.GetAxis("Mouse ScrollWheel");

        //Debug.Log("Mouse X : " + moveX + "Mouse Y : " + moveY + "Scroll" + mouseScroll);

        float mouseXRaw = Input.GetAxisRaw("Mouse X");
        float mouseYRaw = Input.GetAxisRaw("Mouse Y");
        float mouseScrollRaw = Input.GetAxisRaw("Mouse ScrollWheel");

       // Debug.Log("Mouse X : " + mouseXRaw + "Mouse Y : " + mouseYRaw + "Scroll" + mouseScrollRaw);

        //키보드의 Axis 값을 가져와 봄
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardY = Input.GetAxis("Vertical");
        //Debug.Log("Horizontal : " + keyboardX + "Vertical : " + keyboardY);

        float keyboardXRaw = Input.GetAxisRaw("Horizontal");
        float keyboardYRaw = Input.GetAxisRaw("Vertical");
        Debug.Log("Horizontal : " + keyboardXRaw + "Vertical : " + keyboardYRaw);

      

    }
}