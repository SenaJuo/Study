using Unity.VisualScripting;
using UnityEngine;

namespace MyLifeCycle 
{ 
    public class LifeCycle : MonoBehaviour
    {
        /*  
          유니티의 게임오브젝트에 붙는
          C# 스크립트의 생명주기를 확인해 봄
         */

        private Player player;
        private float lastFixedUpdateTime = 0f;
        private float lastUpdateTime = 0f;


        private void Reset()
        {
            Debug.Log("Reset 함수 호출");
            /*
             * 컴포넌트를 사용하다보면, 값들이 초기와 달라지는 경우가 있음
             * Reset 함수에서 초기의 값을 설정하고 난 뒤,
             * Inspector 창에서 Reset 버튼을 누르면,
             * 해당 함수가 자동으로 실행되면서, 컴포넌트의 값을 지정된 초기의 값으로 돌릴 수 있음
             */
        }

        //Awake 함수는 게임이 시작되면 가장 먼저 호출되는 함수임
        //딱 한번만 호출이 됨
        //오브젝트를 껐다가 키는 상황에서는 작동을 안함
        //주로, 변수의 초기화 로직에 많이 사용됨
        private void Awake()
        {
            Debug.Log("Awake 함수 호출");
            //변수 초기화
            //위에 선언된 Player player는
            //현재 값이 할당되지 않은 상태임 (null)
            //Awake에서 초기의 값을 할당해주는것이 좋음
            player = new Player();
        }

        //객체가 켜질때 호출됨
        //ex) 깜짝상자 같은걸 구현한다고 하면,
        //켜질때 마다 깜짝상자의 로직이 구동해야 하므로
        //그럴떄 OnEnable을 쓸 수 있음
        private void OnEnable()
        {
            Debug.Log("OnEnable 호출");
        }

        //Start 함수
        //Awake에서 초기화된 값을 가지고
        //후처리를 해야할 때 사용함
        //Awake 다음 순서가 OnEnable 이긴 한데,
        //OnEnable은 한번만 호출괴는것이 아니고,
        //객체가 켜지지 않으면 영원히 호출이 안됨
        //그래서 Start 함수에서 초기값을 가지고 특정 작업을 함
        //ex)(Player.SetAge(10));

        private void Start()
        {
            Debug.Log("Start 호출");
            player.SetAge(10);
        }

        //FixedUpdate
        //매 프레임 호툴되는 함수
        //게임에서 프레임 단위 작업을 할 수 있게해줌
        //ex)Player가 A지점에서 B지점까지 0.1씩
        //매 프레임 움직여야 할 떄

        private void FixedUpdate()
        {
            //무조건 0.02초마다 호출이 됨
            //호출 주기가 일정하게 보장이 됨
            Debug.Log("FixedUpdate 호출");
            //Time.time << 게임상의 시간을 저장하는 변수
            float current = Time.time;
            //현재시간 - 마지막으로 측정된 시간
            //을 하면 간격이 나올거 같음
            float interval = current - lastFixedUpdateTime;
            //lastFixedUpdateTime을 interval 계산이 끝난 후
            //지금 시간으로 갱신을 해줘야, 다음 측정에서 값이 누적되지 않고,
            //정확한 간격을 자시 측정할 수 있음
            lastFixedUpdateTime = current;
           // Debug.Log("FixedUpdate의 간격 : " + interval);
        }

        //Update도 마찬가지
        //FixedUpdate와 비슷하게, 매 프레임 호출이 됨
        //Log를 찍어보니, FixedUpdate보다 5배정도 많이 찍힘
        //FixedUpdate는 일정 프레임 주기마다 호출이 됨
        //Update는 그냥 마구잡이로 호출이 됨(컴퓨터 성능에 따라 다름)
        //FixedUpdate는 물리처리, 리듬게임 처럼 판정에 민감한 부분에서 많이 사용함
        //그 외 대부분의 경우 Update를 사용하면 됨
        private void Update()
        {
            Debug.Log("Update 호출");
            float currnetTime = Time.time;
            float interval = currnetTime - lastUpdateTime;
            lastUpdateTime = currnetTime;
           // Debug.Log("Update 간격 : " + interval.ToString("F4"));
        }

        //LateUpdate
        //Update 다음에 호출되는 Update라고 생각하면 됨
        //보통 Update에서 플레이어를 움직이고
        //LastUpdate에서 플레이어를 쫓아가는 카메라 로직을 많이 넣음
        //또는 Update에서 계산된 결과를 후처리 해야하는 경우 LateUpdate를 사용함
        private void LateUpdate()
        {
            Debug.Log("LateUpdate 호출");
        }

        //OnDisable은 오브젝트가 비활성화 될 떄 호출됨
        private void OnDisable()
        {
            Debug.Log("OnDisable 호출");
        }

        //오브젝트가 파괴될 때 호출됨
        /*
         * 오브젝트를 파괴하면 한번 호출이 되고,
         * 오브젝트가 파괴되거나 비활성화 되면
         * 모든 Update 호출이 중지됨
         * 다시 재생하면 돌아감
         */
        private void OnDestroy()
        {
            Debug.Log("오브젝트 파괴됨");
        }
    }

        
    public class Player
    {
        private int age = 0;

        public void SetAge(int _age)
        {
            age = _age;
        }
    }
}