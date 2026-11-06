/*<<주석(Comments)
 * 
 * Visual Studio
 * 코드를 작성하기 편하도록 만들어진 메모장
 * 통합개발환경(Intergrated Development Enviornment) IDE
 * 
 * 컴파일(Compile)<<영어로 작성된 프로그래밍 언어를
 * 컴퓨터가 알 수 있는 0과 1로 이루어진 언어로 바꿔주는 과정
 * 
 * 변수와 자료형
 * 
 * 1+2
 * 단순한 연산을 하더라도 사람은 어떤 값을 잠깐 저장하게 됨
 * 컴퓨터도 1과 2를 어딘가에 저장해놨다가 그 값을 가져와서 더하기를 함
 * 컴퓨터는 메모리라는 공간에 값을 저장하게 됨
 * 이때, 필요한 정보가 
 * 얼마나 큰 공간에 저장할건가?
 * 
 * int a = 10;
 * 어떤 정보를 저장할건가? 10
 * 어디에 저장이 되어있는가? a 
 * 0과 1로 이루어진 정보를 어떻게 해석해서 읽을건지 int
 * 
 * 자료형이라는 개념
 * 0과 1로 이루어진 정보를 어떻게 해석할지?
 * 얼마나 큰 공간에 저장할건지?
 * 
 * 변수의 개념
 * 어떤 정보를 저장할건지?
 * 어디에 저장이 되어있는지?
 */

using UnityEngine;
//namespace
//같은 클래스명을 가진 클래스가 생겼을때
//걔네들을 나눠주는 역할, 폴더랑 비슷한 개념임
//윈도우에도 같은 폴더에 같은 이름을 가진 파일리 생성되면 안만들어지는데
//폴더를 다르게 만들어서 같은 이름의 파일을 생성하면 됨(폴더명으로 특정이 되기 때문)
namespace VaraiableStudy
{
public class Variable : MonoBehaviour
{
    //1+2를 한다고 가정해봄
    //1과 2를 어딘가에 잠깐 저장해보고 싶음
    //1,2,-1,-10 >> 정수형
    //정수는 영어로 Integer >> int

    //int라는 공간을 만들고 그 공간의 이름은 a라고 붙이고
    //거기에 2라는 값을 넣어두겠다 라는 뜻
    private void Start()
    {
        
        //자료형과 변수를 사용해서 값을 저장하도 불러와봄
        int a = 2;
        int b = 3;

        //sizeof(int) 가 3이라는 값을 가지고 있다
        int c = sizeof(int);

        Debug.Log(a);
        Debug.Log(b);
        Debug.Log(c);
        //sizeof(int)의 값은 4라는 결과가 나왔음
        //() 자료형의 사이즈를 Byte 단위로 출력해줌

        //Byte가 뭘까?
        //0과 1을 담을 수 있는 칸을 bit라고 부름
        //bit가 8개가 모이면 1byte라고 부름
        //sizeof(int)를 했을때, 4Byte가 나옴
        //즉, 32bit(4*8)라는 크기를 가지고 있음(0과 1을 담을수 있는 칸이 32칸)
        //bit의 개수에 따라서 표현할 수 있는 값의 갯수가 달라짐(2^n - 1, n은bit의 크기)
        //int는 2^32 - 1 만큼 표현이 가능함(42억쯤 됨)
        //부호비트에 하나의 비트를 사용하기 때문에 int가 표현할 수 있는 숫자는 -21억~21억 정도 됨

        //3.14, a, Hello,World
        //같은 정보들을 저장해야 함

        //3.14를 먼저 저장해보려고 함
        //부동 소숫점 방식을 사용하는데, 영어로 floating point방식이라고 함
        //float 자료형 사용
        float f = 3.14f;
        Debug.Log(f);
        int floatSize = sizeof(float);
        Debug.Log(floatSize);

        //a 라는 문자 한개를 저장해봄
        //문자를 영어로 character 라고 함
        //char라는 자료형을 사용
        //문자 하나를 넣을때는 작은따옴표를 씀
        char cc = 'a';
        Debug.Log(cc);

        //'a'라는 문자는 메모리에 97이라는 숫자로 저장되는걸 알고 있음
        //char자료형으로 했을때는 97이라는 숫자가 문자형으로 읽어졌는데
        //int로 읽으면?

        //형변환
        //묵시적 형변환
        //개발자가 형변화을 직접 지시하지 않았는데
        //컴파일러가 임의로 형 변환을 시켜버린 상황
        //(컴파일러는 넓은 자료형을 표현할 수 있는 쪽으로 묵시적 형변환을 함)
        //다른말로 하면, 데이터 유실이 없는쪽으로 형변환을 함
        int ccc = 'a';
        Debug.Log(ccc);

        int charSize = sizeof(char);
        Debug.Log(charSize);

        char abc = 'b';
        Debug.Log((int)abc);//<<명시적 형변환
        //char로 읽히는거를
        //int로 읽어버리고 싶음
        //개발자가 명시적으로 형을 변환시키고 싶음

        //문자열
        //HEllo, Hi, Bye
        /*문자열을 저장하는 방식은
         * 문자들을 일렬로 나란히 세워서 첫번째 문자의
         * 위치만 알고 있다가, 문자 하나의 크기(2Byte)씩 건너뛰면서 읽으면 됨
         * 그래서, 문자열을 저장하는 공간의 크기는
         * 문자열을 구성하는 문자들의 갯수 * 2byte가 됨
         */

        //string
        string str = "Hello";
        Debug.Log(str);

        //어떤 상황이 참인지, 거짓인지
        //0은 거짓이고, 1은 참이겠네?
        //옛날언어들 (C) 언어들은 1bit만 할당하는게 아니라 int형으로 저장을 했음
        //boolean
        //bool
        bool canBuy = false;
        Debug.Log(canBuy);
        Debug.Log(sizeof(bool));

        //object
        //int, char, string, bool, float
        //object형은 다형성 덕분에, 모든 자료형이 들어감
        //Parent parent = new Child();
        //object가 추상화된 부모형태
        //object에 특정자료를 계속 넣게되면 성능상 불이익을 받을 수 있음
        //메모리에는 4가지 종류가 있음
        //Stack, Heap, Data, Code
        //Stack이 값을 읽기에는 가장 빠름
        //동적으로 생성되는 데이터는 Heap에 저장되는데, Heap에 만들고 지울때, Stack에 비해서 상당히 속도가 느림
        //따라서, 어떤 자료를 저장할지 알때는 기본 자료형을 사용해서 Stack에 저장하는게 필요함
        object asdf = 10;
        object asdfasdf = 'a';
        Debug.Log(asdf);
        Debug.Log(asdfasdf);

        //그러면 object는 언제 사용하나?
        //Debug.Log() 처럼 어떤 값이 들어올지 모를때
        //Debug.Log()는 다음의 이유로 게임이 출시할때는 없어야함
        /* 1.object형 사용
         * 2.무언가를 출력하는 작업이 무거움
         * 3.게임에 영향을 안줌(Debug.Log 한번 사용한다고 지대한 영향이 있는건 아니지만,
         * 매 프레임 로그를 출력하거나 하면 영향이 생김
        */

        //var (variable)
        //지역변수에만 사용가능하고
        //Stack메모리에만 상주하고 있음
        //object 보다는 성능상 안전함
        var aaaa = 10;
        var bbbb = 'a';


        //상수 - 변하지않는 수 constant << const
        //변수 - 변하는 수
        //const : 값을 상수로 만들어주는 키워드
        //상수로 선언된 값은 선언 후에 값을 변경할 수가 없음
        //ex. 롤 이라는 게임을 예로들면, 한 팀에 무조건 5명이 들어감(10년이상 바뀌지 않음)
        //이럴때는 최대 플레이어 수를 const로 선언하는것이 안전함
        //(다른 개발자가 수정할 수 있고, 나 혼자 작업한다고 해도, 나중에 까먹고 수정하면 의도와 다른 동작이 나옴)
    }
    }
}