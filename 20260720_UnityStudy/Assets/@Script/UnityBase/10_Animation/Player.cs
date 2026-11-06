using UnityEngine;
namespace MyAnimation 
{
    /*
     * Rigidbody를 사용해서 Player의 움직임을 구현할깨
     * 무조건 Rigidbody가 필요함, 그때 RequireComponent를 사용해서
     * Player 스크립트가 있는 오브젝트에 무조건 Rigidbody를 달도록 할 수 있음(삭제 불가능)
     * 
     * Composition(합성)
     * 캡슐화된 클래스를 종합하여 기능을 구현하는 방식
     * ex. Player는 껍데기만 남겨두고, PlayerMovement, PlayerAnimation 컴포넌트로 나눠서
     * 각자의 기능을 구현하고, Player가 그 기능들을 가져와서 조합만 하는 방식
     */
    [RequireComponent(typeof(CapsuleCollider))]
    
    public class Player : MonoBehaviour
    {
        private PlayerMovement playerMovement = null;
        private PlayerAnimation playerAnimation = null;

        /*
        Reset << 컴포넌트의 초기값을 제어하고 싶을때 사용함
        Awake나 Start는 게임이 시작될 떄 호출되는 반면
        Reset함수는 게임 시작 전, 컴포넌트가 오브젝트에 붙을때 한번 실행됨
        그래서 기본 설정 같은거 할때 Reset에서 하면 됨
        */
        private void Reset()
        {
            CapsuleCollider collider = GetComponent<CapsuleCollider>();
            collider.center = new Vector3(0f, 0.97f, 0f);
            collider.radius = 0.3f;
            collider.height = 2f;
        }

        private void Awake()
        {
            playerAnimation = GetComponentInChildren<PlayerAnimation>();
            playerMovement = GetComponent<PlayerMovement>();

        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                playerAnimation.GetSetTrigger("Fire");
            }
            playerAnimation.GetSetFloat("MoveSpeed", playerMovement.GetCurrentMoveSpeed());
        }
    }
}
