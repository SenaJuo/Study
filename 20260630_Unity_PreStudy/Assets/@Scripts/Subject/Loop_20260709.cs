using UnityEngine;

public class Loop_20260709 : MonoBehaviour
{
    private void Start()
    {
        /* 1번 문제
         * 1단을 풀어야 한다
         * 1X1=1
         * 1X2=2
         * 1X3=3
         * 1단이면 1이라는 숫자가 고정임
         * 1에 곱해지는 수를 보면, 1~9까지 1씩 증가하면 될거같음
         * 결과는 1과 1~9까지의 수를 곱한 결과임
         * 
         * 1을 박아놓고 1~9까지의 수를 반복하면서 곱해줄 로직이 필요함
         * x=1, y=1
         * x=1, y=2
         * x=1, y=3
         * ...
         * x=1, y=9
         * 
         * 2중 반복문을 사용하면 해결이 될 거 같네
         */

        /* int dan = 11;
         for (int i = 1; i <=dan; ++i) //단
         {
             Debug.Log(i + "단-----------");
             for (int j = 1; j < 10; ++j) //곱해지는 값
             {
                 Debug.Log(i+" X " +  j + " = " + i*j);
             }
         }
        */

        /* 2번 문제
         * [ ],[ ],[ ],[ ],[ ],[ ]
         * [ ],[ ],[ ],[ ],[ ],[ ]
         * [ ],[X],[ ],[ ],[ ],[ ]
         * [X],[ ],[ ],[ ],[ ],[ ]
         * [ ],[ ],[ ],[X],[ ],[ ]
         * 14, 19, 28번째 칸에 지뢰
         * 지뢰는 3개, 지뢰를 모두 발견하면 게임이 종료
         * 매칸 확인할 때 마다 xx칸 확인 중
         * 지뢰를 찾으면 xx칸에 있는 지뢰 확인완료
         * 1. 일단 지뢰를 확인해보려면 모든 칸을 돌아봐야함
         * -2중 반복문을 사용해서 해결
         * 2. 모든 칸을 들여다보는건 완료를 했음
         * - 칸을 들여다보고 있는데, 만약에, 지뢰가 있는 칸이라면
         * 지뢰를 확인했다 라고 출력하면 됨
         */

        int totalMine = 3;
        int findedMineCount = 0;
        for (int i = 0; i < 5; ++i)
        {
            for (int j = 0; j < 6; ++j)
            {
                int currentStep = i * 6 + j; //현재 몇번 째 칸 인지
                Debug.Log(currentStep+"칸 확인중...");
                if (currentStep == 14 || currentStep == 19 || currentStep == 28)
                {
                    ++findedMineCount;
                    Debug.Log(currentStep + "번째 칸은 지뢰였습니다.");
                    if(findedMineCount == totalMine)
                    {
                        break;
                    }
                }
            }
        }
    }
}
