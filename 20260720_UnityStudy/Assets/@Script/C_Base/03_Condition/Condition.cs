using UnityEngine;

//alt + 위 아래 방향키 : 줄 위치 이동
//자동 줄 정렬 : ctrl + k + d
namespace Condition_Study
{

    //디버깅
    //Debuging
    //F5 : Visual Studio 디버깅 모드 시작
    //F9 : 코드라인에 중단점(Break Point) 걸기
    //F10 : 다음 라인으로 이동
    //ctrl + shift + F9 : 모든 중단점(Break Point) 해제
    public class Condition : MonoBehaviour
    {
        //조건문
        //Condition

        /*
         * 내 지갑에 10000원이 있음
         * 5000원짜리 아이템을 구매할건데
         * 만약에, 아이템 가격보다 내 지갑에 돈이 많은 경우에, 아이템을 구매함
         * if문을 써서 해당 요구사항을 구현해봄
         * if(조건)
         * {
         *      조건이 참일때 실행할 행동
         * }
         * 그게 아니라, 내 지갑에 있는 돈이 아이템 가격보다
         * 적으면, 아이템을 구매할 수 없다를 출력하고 싶음
         * 
         * if문은 조건이 참일때만, 중괄호 안에 있는 행동이 실행됨
         */

        private void Start()
        {
            int wallet = 10000;
            int itemPrice = 5000;

            if (wallet >= itemPrice)
            {
                wallet -= itemPrice;
                Debug.Log("아이템 구매");
                Debug.Log(wallet+"원");
            }
            else
            {
                Debug.Log("아이템을 구매할 수 없습니다.");
            }

            //if ~ else 문을 확인해봄
            //만약에 특정 조건을 만족하는지 확인해보고
            //그게 아닌 경우에 다른 행동을 하고싶을때 사용함
            //if문으로 먼저 조건을 확인해야, 그게 아닌 경우가 확인이 되므로
            //else문 단독으로 사용하는것은 안됨
            /*
             if(조건문)
             {
             
             
             }
             else
             {
             
             }
             */

            //내 지갑에 10000원이 있는데
            int wallet1 = 10000;
            int taxiPrice = 5000;
            int busPrice = 3000;
            int kickboardPrice = 1000;
            //집에 갈 교통수단을 정하고 싶음
            //만약에, 지갑에 5000원 이상이 있으면, 택시
            //그게 아니라, 만약에 지갑에 3000원 이상이 있으면 버스
            //그게 아니라, 만약에 지갑에 1000원 이상이 있으면 킥보드
            //모든 경우에 속하지 않으면 도보
            if (wallet >= taxiPrice)
            {
                Debug.Log("택시 탑승");
            }
            else if (wallet >= busPrice)
            {
                Debug.Log("버스 탑승");
            }
            else if(wallet >= kickboardPrice)
            {
                Debug.Log("킥보드로 이동");
            }
            else
            {
                Debug.Log("도보 이동");
            }

            /*
             * if-else if-else문
             * 만약에 ~면 ~하고 싶음
             * 그게 아니라 만약에 ~면 ~하고싶음
             * 위 경우에 하나도 맞지 않는다면 ~하고싶음
             * 
             * 위 요구사항을 충족할때 if - else if- else 문을 사용함
             * if -else if -else문의 특징은, 조건들의 블록에서 하나라도 탐인 조건이 나온다면,
             * 아래 조건을 따로 검사하지 않음
             * 
             * 요구사항이 모든 조건을 검사해야 한다면,
             * if문을 여러개 써서, 모든 조건을 검사하게 해야함
             * 
             */

            //switch문
            //if문이랑 같은 역할을 함
            //if문을 썼는데, 가독성이 떨어질 때가 있음

            /*
             * 게임에 진입을 했음
             * 레벨 1일때는, 초보자의 사냥터로 이동시킬거고
             * 레벨 2일때는, 중급자의 사냥터로 이동시킬거고
             * 레벨 3일때는, 고급자의 사냥터로 이동시킬거고
             * 레벨 4일때는, 보스맵으로 이동시킬거임
             * 그 외에 모든 경우에서 레벨 오류! 를 출력할거임
             */

            int playerlevel = 4;

            if (playerlevel == 1)
            {
                Debug.Log("초보자의 사냥터로 이동");
            }
            else if (playerlevel == 2)
            {
                Debug.Log("중급자의 사냥터로 이동");
            }
            else if(playerlevel == 3)
            {
                Debug.Log("고급자의 사냥터로 이동");
            }
            else if(playerlevel == 4)
            {
                Debug.Log("보스맵으로 이동");
            }
            else
            {
                Debug.Log("레벨 오류");
            }

            /*
            switch(변수)
            {
                case 변수값 : 
                break;

                default : 
                break;
            }
            */

            switch (playerlevel)
            {
                case 1:
                    Debug.Log("초급자의 사냥터로 이동");
                    break;

                case 2:
                    Debug.Log("중급자의 사냥터로 이동");
                    break;
                
                case 3:
                    Debug.Log("고급자의 사냥터로 이동");
                    break;
                
                case 4:
                    Debug.Log("보스맵으로 이동");
                    break;

                default:
                    Debug.Log("레벨 오류");
                    break;

            }

            //if문을 중첩해서 사용할 수 있음
            /*ex. 택시를 탈 수 있는 상황이면 아래 코드 실행
             if(조건)
            {
             택시를 탈 수 있는 상황에서 내가 기사님께
             팁도 드릴 수 있는지 체크  
                if(조건)
                {
                    택시를 탈 수 있으면서
                    팁도 드릴 수 있는 상황에서 실행
                }
            }

            --------------------------------------------

            if(택시를 탈 수 있는가? && 팁을 드릴 수 있는가?)
            {
                택시를 탈 수 있는 조건과 팁을 드릴 수 있는 조건이
                모두 참일때 실행되는 코드
            }
             */


            /*
            삼항연산자
            result라는 string 변수가 있음
            만약에, 엑조디아 카드가 5장 이상 모였다면,
            result에는 엑조디아 소환! 이라는 문구를 넣을거고
            그렇지 않으면, 엑조디아 소환 불가! 라는 문구를 넣을거임
            */

            string result = "";
            int cardCount = 0;
            if(cardCount >= 5)
            {
                result = "엑조디아 소환";
            }
            else
            {
                result = "엑조디아 소환 불가";
            }
            Debug.Log(result);

            //삼항연산자 형태
            //조건 ? 참일때 반환 : 거짓일때 반환

            result = cardCount >= 5 ?  "엑조디아 소환!1" : "엑조디아 소환 불가1";
            Debug.Log(result);
        }
    }
}

