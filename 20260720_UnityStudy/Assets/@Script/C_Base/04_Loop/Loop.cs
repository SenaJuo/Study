using UnityEngine;

namespace Loop_Study
{
    public class Loop : MonoBehaviour
    {
        private void Start()
        {   
            //주석 단축키 ctrl + k + c   or    ctrl + /
            //주석 해제   ctrl + k + u   or    ctrl + /

            //반복문
            //Loop

            //아이템을 구매하는 행동을 5번 실행할거임
            int boughtItemCount = 0;

            //Debug.Log("아이템 구매!");
            //++boughtItemCount;
            //Debug.Log(boughtItemCount);

            //for문
            //for (지역변수 생성; 생성된 변수의 조건; 변수의 증감;)
            //{
            //  반복이 진행되는 중에 실행될 코드
            //}


            //반복문을 쓰지 않게 됐을때,
            //코드의 바녹횟수만큼 코드를 작성해야 하는 단점과
            //반복할 코드를 수정랄 때 반복된 코드의 갯수만큼
            //수정해야 하는것이 불편했음

            //위 단점을 해결하고자 반복문이라는 개념이 등장함

            for (int i = 0; i < 5; ++i) 
            {
                Debug.Log("아이템 구매!");
                ++boughtItemCount;
                Debug.Log(boughtItemCount);
            }

            for(int i = 0; i< 10; ++i)
            {
                Debug.Log(i);
            }

            for(int i = 10; i>0; --i)
            {
                Debug.Log(i);
            }

            for (int i = 0; i < 10; i += 2)
            {
                Debug.Log(i);
            }

            //반복을 할건데
            //5번 반복을 하고 싶음
            //만약에, i의 값이 3이라면, 반복을 중단하고 싶음

            for(int i =0; i< 5; ++i)
            {
                Debug.Log(i);
                if (i == 3)
                {
                    break;
                }
            }

            //5번 반복을 할건데 i가 3일때만 반복을 한번 건너뛰고 싶음
            for(int i =0; i<5; ++i)
            {
                
                if (i == 3)
                {
                    continue;//만나면 다음반복으로 넘어감
                }
                Debug.Log(i);
            }

            //for
            //반복횟수가 명확했음
            //while 문을 사용함
            //플레이어랑 적이 싸우는데
            //적이 죽을때까지는 플레이어가 공격을 해양함
            //이럴때는, 반복횟수를 정할 수 없기 때문에
            //for문을 사용할 수 없음

            //while(반복을 지속할 조건)
            //{
            //  반복중에 실행할 행동
            //}

            //소괄호 안에 있는 조건이 참일때 동안
            //반복이 실행됨

            float playerDamage = 20f;
            float enemyHp = 100f;
            //적이 살아있을때 동안, 공격을 계속 해야함
            //적이 살아있을때 라는 조건 넣어주면 됨
            while(enemyHp > 0f)
            {
                Debug.Log("플레이어가 적을 공격 시작함");
                enemyHp -= playerDamage;
                Debug.Log(enemyHp);
            }

            //반복문 안에 반복뮨울 넣어보고 싶음
            //for
            for(int i = 0; i < 3; ++i)
            {
                for (int j = 0; j <5; ++j)
                {
                    Debug.Log("i : " + i + " j : " + j);
                }
            }

            //구구단
            //바깥쪽 반복문: 단(2~9), 안쪽 반복문: 1~9를 곱함
            for (int dan = 2; dan <= 9; ++dan)
            {
                for (int i = 1; i <= 9; ++i)
                {
                    Debug.Log(dan + " x " + i + " = " + (dan * i));
                }
            }
        }
    }
}