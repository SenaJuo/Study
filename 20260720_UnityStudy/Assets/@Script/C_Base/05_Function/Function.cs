using UnityEngine;

public class Function : MonoBehaviour
{
    private void Start()
    {
        /*
        함수 (Function)
        함수는 기능의 단위
        ex)카카오톡 : 로그인하는 기능, 채팅 보내는 기능, 채팅 치는 기능...
           계산기 : 더하기, 빼기, 곱하기, 나누기...
        프로그램에 있는 기능들의 단위를 함수라고 부름

        함수의 구성요소
        어떤 값을 넣을것인가? << 입력
        어떤 행동을 할것인가? << 행동
        어떤 값을 결과로 내보낼 것인가? << 출력
        이 일련의 행동을 하는 함수를 뭐라고 부를 것인가? << 함수명

        함수의 구성 : 출력값의 형태 -> 함수의 이름 -> 함수의 입력값 ->
        {
           함수가 해야하는 행동
           return 출력값
        }

        입력으로 1과 3을 받아야 함
        행동은 입력으로 받은 1과 3을 더해줘야 함
        출력으로는 행동에서 더한 값을 저장했다가
        그 값을 출력으로 만들어 줘야 함
        위 행동을 하는 함수를 Add라고 부를거임

        입력은 둘다 int형으로 만들어 주면 될거 같음
        입력으로 받은 1과 3을 더해주면 끝남
        1과 3을 더한 값을 잠깐 저장했다가 출력으로 정수형 결과(4)를 내보내 주면 됨
        이 함수를 Add라는 이름으로 부르면 됨
        */
        int addValue = Add(1, 3);
        Debug.Log(addValue);

        Introduce();

        int change = BuyItem(10000, 1000);
        Debug.Log(change);

        //함수를 왜 써야할까?
        //1. 함수의 내용을 다 이해할 필요 없이
        //함수명만 보고 해당 기능을 사용할 수 있음
        //ex.Debug.Log();
        
        //2. 함수를 사용하면, 함수를 사용하는 모든곳이
        //함수의 정의를 바탕으로 동작하므로,
        //함수의 정의부만 바꿔주면, 동작을 사용하는 모든곳을 찾아가서 바꿀 필요 없음
        //참조(Reference)의 개념

        //3. 코드의 중복을 줄일 수 있음
        //(함수를 한번만 만들어 놓으면, 함수를 사용하면 되기 때문)

        //함수 오버로딩(Function overloading) 
        //변수는 같은 이름으로 선언하면
        //같은 이름 내에서 서로를 구분할 방법이 없음
        //함수는 같은 이름으로 선언했을때,
        //입력의 갯수로 함수를 구분할 수 있음
        //즉, 같은 함수명에 인자의 갯수만 다르게 해서 선언하는 방법을
        //함수 오버로딩(function overloadion)이라고 함
    }
    
    int Add(int value, int value2)
    {
        int result = value + value2;
        return result;
    }
    /*Debug.Log("안녕하세요!");
    Debug.Log("제 이름은 김준익 입니다.");
    두가지의 문구를 출력하는 함수를 만들어 봄
    행동은 DebugLog를 2개 찍기
    함수 이름은 Introduce
    입력으로 받을 값은 없는듯
    출력도 없는듯
    출력이 없을때 쓰는 자료형 << void(공허한)
    반환값이 void인 경우에는, return은 생략 가는ㅇ함
    하지만, 명시적으로 return 키워드를 넣어도 됨
    여기서 주의해야 할 점이 함수는 return 키워드를
    만나게 되면 종료가 되기 때문에, 주의해서 사용해야 함
    */

    void Introduce()
    {
        Debug.Log("안녕하세요!");
        Debug.Log("제 이름은 김준익 입니다.");
        return;
    }
    /*
     * 예외사항 처리(Exception Handling)
     * return 키워드의 특징을 사용해서
     * 예외를 처리할 수 있다
     */

    //아이템을 구매하는 함수를 하나 만들어봄
    //BuyItem 이라는 함수 이름을 사용할거임
    //보통 함수 이름을 지을때, 동사 + 명사 로 많이 지름
    //사용자의 가지고 있는 돈과, 아이템의 가격을 비교해서
    //아이템을 살 수 있다면, 아이템 구매! 라는 문구를 띄워주고
    //사용자의 남은 잔돈을 출력으로 내보내줌

    //사용자가 가지고 있는 돈은 10000원
    //아이템 가격은 1000원

    int BuyItem(int wallet, int itemPrice)
    {
        //지금은 함수 설계는 wallet의 돈이 무조건 itemPrice보다
        //크다는걸 상정하고 만들었음
        //wallet의 돈이 itemPrice보다 작아지니까
        //예외(Exception)상황이 발생해버림

        //wallet에 있는 돈과 itemPrice를 비교해서
        //만역에, wallet에 있는돈이 itemPrice보다 작다면
        //아이템을 구매할 수 없다를 풀력하고
        //그냥 내 지갑에 있는 돈을 내보내줌
        if(wallet < itemPrice)
        {
            Debug.Log("아이템을 구매할 수 없음");
            return wallet;
        }

        int result = wallet - itemPrice;
        Debug.Log("아이템 구매 완료!");
        return result;
    }
}
