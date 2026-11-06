using Unity.VisualScripting;
using UnityEngine;

public class Function : MonoBehaviour
{
    //Function
    //함수
    //함수<->기능의 단위
    private void Start()
    {
        //함수 호출 방법
        //함수도 변수와 마찬가지로 이름을 기준으로 호출함
        //사용하는 방법은 /함수 이름(입력값)/의 형태로 사용함
        //만약 출력값이 있다면, 변수를 활용해서 출력값을
        //저장하고 사용할 수 있음
        //함수 호출에 사용되는 입력을 '인자(Arguments)'라고 부름
        //함수 정의에 사용되는 입력을 '매개변수(Parameter)'라고 부름

        int addValue=Add(200, 400);
        Debug.Log(addValue);

        Debug.Log(GetFiveValue());//인라인 함수호출(inline function call)
        
        SomeFunction();

        
        
        int currentLevel = AddLevel(-1);
        if(currentLevel != -999)
        {
            Debug.Log("현재 플레이어의 레벨은" + currentLevel + "입니다.");
        }
        /*함수를 배우긴 했는데
        함수를 쓰면 좋은점이 뭘까?
        1. 함수 로직을 전부 이해할 필요가 없음
        -함수에는 함수명이 있기 때문에, 함수 코드를
        전부 분석하지 않아도, 어떤 역할을 하는 함수인지 알 수 있음
        
        2. 기능을 쓸때마다, 같은 로직을 구현할 필요가 없음 >> 참조(Reference)
        
        함수를 사용해서 함수의 기능을 참조
        >>프로그램의 관리 포인트를 줄일 수 있음
        */
        
        ShowItemBuyPopup();
        ShowItemBuyPopup();
        ShowItemBuyPopup();
        ShowItemBuyPopup();
        ShowItemBuyPopup();
        ShowItemBuyPopup();

        /*Debug.Log("------------------------");
          Debug.Log("-- 1번 아이템 구매 완료 --");
          Debug.Log("------------------------");

          Debug.Log("------------------------");
          Debug.Log("-- 1번 아이템 구매 완료 --");
          Debug.Log("------------------------");

          Debug.Log("------------------------");
          Debug.Log("-- 1번 아이템 구매 완료 --");
          Debug.Log("------------------------");

          Debug.Log("------------------------");
          Debug.Log("-- 1번 아이템 구매 완료 --");
          Debug.Log("------------------------");

          Debug.Log("------------------------");
          Debug.Log("-- 1번 아이템 구매 완료 --");
          Debug.Log("------------------------");

        함수의 부가기능
        1.함수의 overloading(오버로딩) 기능
        Add(1,2)
        3+5+7
        Add(3,5,7)
        변수의 경우 같은 변수명이면,
        변수를 구분할 수 있는 방법이 없었음
        함수의 경우는 사용할 때, 이름이 같아도
        함수의 인자의 갯수로 함수를 구분할 수 있음
        같은 함수명에, 인자의 갯수를 다르게 하는 방식으로
        함수를 여러개 정의할 수 있는 방법이
        함수 오버로딩(overloading)임 << 자주 사용함

        함수의 이름을 명확하게 하는것이 중요함
        */

        Debug.Log(Add(1, 2));
        Debug.Log(Add(1, 2, 3));
        Debug.Log(Add(1f, 2f));

        /*
         * 디폴트 매개변수 (Parameter)
         * 함수 오버로딩이랑 비슷한 개념임
         * 함수 정의할때, 매개변수에 기본값을
         * 설정할 수 있는 기능
         */
        Debug.Log(GetValue());
        Debug.Log(GetValue(3));

        /*디폴트 매개변수를 사용해서 함수를 오버로딩 한것처럼 사용할 수 있음
         * 하지만 디폴트 매개변수는 함수 하나에서 인자의 값에 따라
         * 모든 로직을 처리해야 하기 때문에
         * 함수 하나가 너무 비대해지고 가독성이 떨어짐
         * 상황에 따라 함수를 overloading할지, default parameter를 사용할지 결정해야 함
         */
    }
    /*
    함수를 만들려면
    함수의 행동
    함수의 이름
    입력(어떤 형태의 자료를 입력할건지 - 자료형 필요)
    출력(어떤 형태의 자료를 출력할건지 - 자료형 필요)
    출력값의 자료형 / 함수의 이름 / (입력할것들)
    {
          함수에서 실행할 행동
          return 출력값
    }
    */

    //정수 값 2개를 입력으로 받아서 더하기를 하고
    //더한 값(정수)를 출력으로 내보내는
    //Add라는 이름을 가진 함수를 만들어 봄

    int Add(int i, int ii)
    {
        int result = i + ii;
        return result;
    }
    //실수 2개를 받아서
    //억지로 int형으로 형 변환하고
    //2개를 더해서 출력해주는 함수

    int Add(float f, float ff)
    {
        int result = (int)f + (int)ff;
        return result;
    }
    int Add(int i, int ii, int iii)
    {
        int result = i + ii + iii;
        return result;
    }

    //함수를 하나 만들건데
    //그냥 5라는 값을 출력하는 함수를 만들고 싶음
    //GetFiveValue라는 이름으로 만들거임
    //입력은 필요가 없음
    //행동은 다른거 없이 그냥 출력하는 행동만 할거임
    int GetFiveValue()
    {
        return 5;
    }

    //입력값도 없고, 출력값도 없는 함수를 만들어 봄
    //정수형을 출력하는 함수를 만들때 -> int라는 자료형을 앞에 붙여줌
    //출력값이 없을때, 사용하는 자료형 -> void

    void SomeFunction() 
    {
        //출력이 없는 void형의 함수의 경우
        //return뒤에 값이 없기 때문에, return이 있든 없든, 별 상관이 없음
        //그래서 C# 에서는 return 키워드를 생략할 수 있음
        //하지만, 함수 자체는 return 키워드를 만나면
        //결과를 출력(반환)하기 때문에,
        //return 키워드를 로직 위에 써버리면
        //로직이 실행전에 아무것도 없는 값을 반환해서 함수가 일찍 종료될 수 있음
        //return;
        Debug.Log("SomeFunction 호출됨!");
        
    }
    //양수의 값만 받아서 더하기를 하는 함수를 만들어봄
    //레벨을 더하는 함수<<레벨은 음수가 되면 안되기 때문에, 음수가 들어오면 안됨
    //무조건 레벨은 1만 오름
    int AddLevel(int level)
    {
        //예외상황 처리
        //Exception Handling
        //원하지 않는 값이 들어왔을때, 함수가 동작하지 않도록 하는 기법
        //또는 약속된 에러코드를 출력해서, 함수를 사용하는 사람이
        //에러코드를 받았을때, if문을 통해서 예외상황을 만나지 않도록 하는 기법
        if (level < 0)
        {
            return -999;
        }
        return level + 1;
    }
    
    // 1번 아이템을 구매하면,
    // 1번 아이템을 구매하였습니다.! 하는 문구를 띄워주는 기능을 할거임

    void ShowItemBuyPopup()
    {
        Debug.Log("-x-x-x-x-x-x-x-x-x-x-x-x-");
        Debug.Log("--- 1번 아이템 구매 완료 ---");
        Debug.Log("-x-x-x-x-x-x-x-x-x-x-x-x-");
    }

    //정수형 값을 내보내는 함수
    //입력으로 아무것도 안들어오면
    //0을 내보낼거고
    //입력으로 어떤 값이 들어오면
    //입력된 수를 바로 내보낼거임

    int GetValue(int i = 0)
    {
        return i;
    }
}
