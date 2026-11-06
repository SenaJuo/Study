using UnityEngine;

public class Operator : MonoBehaviour
{
    //연산자
    //operator

    //산술 연산자
    //+, -, *, /, %(나머지 연산자)

    //대입연산자
    //int a = 10;
    // =, +=, -=, *=, /=, %=

    //비교연산자
    // >, <, <=, >=, ==(같다)

    //논리연산자
    // &&, ||, !

    //비트연산자
    // &, |, ^, <<, >>, ~

    //증감연산자
    //++, --

    private void Start()
    {
        int lhs = 10; //left hand side
        int rhs = 2; // right hand side

        Debug.Log(lhs + rhs);
        Debug.Log(lhs - rhs);
        Debug.Log(lhs * rhs);
        Debug.Log(lhs / rhs);

        //%
        //좌항에 있는 녀석을 우항으로 나눈 결과에서 몫을 빼고, 나머지만 가져오는 연산자
        // 10 / 3 = 3...1
        //10 % 3 = 1

        Debug.Log(10 % 3);

        //비교연산자
        // 3 > 5
        bool b1 = 3 > 5;
        Debug.Log(b1);

        //복합 대입 연산자
        //= ,+=, -=, *=, %=
        //1. 지갑에는 10000원이 있음
        int wallet = 10000;
        // 2. 음료수가 2000원임
        int drinkPrice = 2000;
        // 3. 잔돈을 출력하기
        //wallet = wallet - drinkPrice; //위 아래 같은 뜻
        wallet -= drinkPrice;
        Debug.Log(wallet);

        //논리연산자
        //&&(AND), ||(OR), !(NOT)


        //&& (AND)
        //조건 2개가 모두 참 >> 참
        bool b2 = 3 < 5;
        bool b3 = 5 > 2;
        bool b4 = b2 && b3;
        Debug.Log(b4);

        // ||(OR)
        //조건 2개 중의 하나가 참일때 >> 참
        bool b5 = 3 > 5;
        bool b6 = 3 < 5;
        bool b7 = b5 || b6;
        Debug.Log(b7);
        
        //!(NOT)
        //결과의 반전
        Debug.Log(!true);
        Debug.Log(!false);
        
        //논리연산자 우선순위
        //!연산자가 제일 빨리 계산이 됨
        //만약 모든 연산의 결과를 발전시키고 싶으면
        //먼저 연산하고 싶은걸
        //중괄호를 묶어서 연산하면 됨
        Debug.Log(!false || false);
        Debug.Log(true || false); ;

        //증감연산자
        // ++, --
        int ii = 0;
        //변수의 값을 딱 한개 올리고 싶을때 사용함
        //선증감 연산자
        //++ii ii의 값을 하나 더 더하고 연산
        //++ii;
        //--ii;
        Debug.Log(ii++);
        //Debug.Log(ii);

        int value = 0;
        Debug.Log(++value + value++ + ++value + value++);
                //    1   +   1     +   3     +    3
        Debug.Log(value); //라인 바뀌면서 후증감 계산이 적용되어서 value값은 4가 나옴
        //후증감 연산자
        //ii++ 기존의 ii의 값을 가지고 연산한 다음, 다음 라인에서 ii의 값을 더해줌
        //ii++;
        //Debug.Log(ii);
        //ii--;
        //Debug.Log(ii);

    }
}
