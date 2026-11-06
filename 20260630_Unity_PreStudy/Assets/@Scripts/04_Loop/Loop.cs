using UnityEngine;

public class Loop : MonoBehaviour
{
    private void Start()
    {
        /*반복문(Loop)
         * 특정행동을 반복하는 구문임
         * 1.얼마나 반복할건지가 필요함
         * 2.어떤 행동을 반복할지
         * 
         * for, while
         
         * for문
         * 1.얼마나 반복할건지가 필요함
         * for문에서 얼마나 반복할지를 결정
         * 변수, 변수의 값을 관찰함, 변수값을 바꿔줌
         * 변수의 값이 제가 설정한 범위 안이면 계속 반복함
         * 
         * for(변수선언; 조건설정; 변수값조절)
         * 2.어떤 행동을 반복할지
         * {
         * }
         * for(변수선언; 조건설정; 변수값조절)
         * {
         * }
         */

        //안녕하세요! 를 5번 출력
        Debug.Log("안녕하세요!");
        Debug.Log("안녕하세요!");
        Debug.Log("안녕하세요!");
        Debug.Log("안녕하세요!");
        Debug.Log("안녕하세요!");

        Debug.Log("-------------------");

        //반복문이 돌아가는 방식
        //1.초기에 변수 선언함
        //2.변수의 값과 조건을 비교
        //3.조건이 참이면 중괄호 안의 내용 실행
        //4.중괄호 내의 모든 코드가 실행되면 i의 값을 바꾸는 코드 실행
        //5.2,3,4,번을 반복하다가 조건이 거짓이 되는 순간 반복 종료
        //(tip>>선증가, 후증가 연산자의 차이가 없기 때문에, 성능이 더 좋은 선증가 연산자를 사용하는걸 권장함)
        for (int i =0; i<5; ++i)
        {
            Debug.Log("안녕하세요!");
            Debug.Log("i의 값은 : "+i);
        }
       for(int i =5; i>0; --i)
        {
            Debug.Log("i의 값은 : " + i);
        }

       //반복은 할건데
       //i의 값을 2씩 건너뛰고 싶음
        for(int i=0; i<10; i+=2)
        {
            Debug.Log("i의 값은 : " + i);
            
        }
        //반복을 돌리긴 할건데
        //0부터 5까지 i가 증가할때
        //i의 값이 3일때만 "3입니다!"를 출력하고 싶음
        //반복뮨 안에 if문을 써서 구현 할 수 있음

        //i가 3이되면, 반복을 멈추고 싶음
        //break
        //i가 3이 되면, 반복을 한번 건너뛰고 싶음
        //i가 3일때, 아무행동도 하고싶지 않음
        //continue
        for(int i=0; i<5; ++i)
        {
            if (i == 3)
            {
                continue;
                Debug.Log(i+"입니다!");
            }
            else
            {
                Debug.Log("x");
            }
        }
        /*게임을 돌리고 있음
        플레이어가 이동을 하면서
        A라는 지점에 도달하기 전까지
        계속 반복을 하고 싶음
        조건을 제대로 확인 할 수 없을때
        while문 사용
        while(~까지 해당하는 조건)
        {
            반복할 행동을 넣으면 됨
        }

        플레이어 위치를 하나 정함
        int playerPosition = -10;
        도착지점도 하나 정할거임
        도착 안했으면 Debug.Log("플레이어 방황중"); 출력
        */
        
        int playerPosition = -10;
        int targetPosition = 20;
        
        //playerPosition의 위치가 targetPosition의 위치랑 같을 때 까지
        while(playerPosition!=targetPosition)
        {
            Debug.Log("플레이어 방황중");
            ++playerPosition;
        }

        Debug.Log("반복이 끝난 player의 위치 : " + playerPosition);

        //이번에 해보고 싶은건
        //3행 4열짜리 표를 반복하면서 확인하고싶음
        //행마다 열을 반복하는 행동이 반복됨
        //반복이 반복된다
        //>>반복문을 2개 쓰자
        for (int i = 0; i<3; ++i)
        {   
            for(int j=0; j<4; ++j)
            {
                Debug.Log("i의 값 : " + i + " j의 값 : "+j);
            }
        }

    }
}
