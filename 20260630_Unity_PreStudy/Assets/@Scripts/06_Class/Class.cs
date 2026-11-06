using NUnit.Framework.Constraints;
using UnityEngine;

//class -> 어떤 작은 물건을 만들기 위한 설계도
//class -> 분류
//자동차
//1.페달
//----------
//2.핸들 손잡이
//3.핸들 가죽
//----------
//4.엔진 나사
//5.엔진 기름

//class에는 같은 분류의 정보들이 들어가있음 -> 변수
//class에는 특정 기능이 있어야 함 -> 함수(기능)
//-> class는 같은 속성을 가진 변수와 함수의 집합
/*엔진이라는 분류
 * Engine이라는 이름을 가진 class
 * Engine이라는 class에는 Engine을 구성하는 정보와 엔진의 기능이 정의되어 있음
 * Engine을 구성하는 변수와 함수가 존재한다
 * 
 * class안에 존재하는 변수와 함수를 멤버 변수, 멤버 함수 라고 함
 **/
public class Class : MonoBehaviour
{   
    //모니터
    //1. 화면을 보여주는 역할(144hz) - 변수, 함수
    //2. 제조사 : 삼성 - 변수, 함수

    //마우스
    //1. 좌클릭 했을떄, 좌클릭! 이라는 문구 띄워주기
    //2. 우클릭 했을때, 우클릭! 이라는 문구 띄워주기
    //3. 마우스 휠을 굴렸을때, 휠 굴림! 이라는 문구 띄워주기
    //4. 제조사 : 로지텍
    private void Start()
    {
        /* //모니터
         int monitorRate = 144;
         string monitorBrand = "삼성";
         DisplayMonitor(monitorRate);
         PrintMonitorBrand(monitorBrand);

         //마우스
         string mouseBrand = "로지텍";
         ClickMouseLeft();
         ClickMouseRight();
         ScrollMouseWheel();
         PrintMouseBrand(mouseBrand);
        */

        //분류를 하기는 했는데 실행하려고 보니
        //class라는 class에는 아무것도 없음
        //기능이나 변수들이 다른 class로 넘어갔기 때문
        //class -> 설계도
        //설계도를 바탕으로 어떤 객체를 만들거임

        //모니터라는 설계도를 가지고 모니터를 만든거임
        Monitor monitor = new Monitor();
        //멤버 접근 연산자(.)
        //monitor라는 객체 안에 있는 멤버 함수인 DisplayMonitor()라는 함수를 사용(호출)하고 싶음
        //monitor에 멤버 접근 연산자 .을 사용해서
        //그 안에 있는 멤버함수인 DisplayMonitor()를 호출
        monitor.DisplayMonitor();
        monitor.PrintMonitorBrand();
        //string monitorBrand = monitor.GetMonitorBrand();
        //monitor.monitorBrand = "LG";
        monitor.SetMonitorBrand("LG");
        Debug.Log(monitor.monitorBrand);

        //멤버 변수에 접근해서 값을 바꿔야하는 경우도 생김
        //이때, 멤버 변수 보다는 멤버 함수를 사용해서 값을 바꾸는 방식을 권장함
        //이유는 함수를 사용해서 구현해야, 기능의 확장이 일어날 때,
        //관리포인트가 함수 1개로 특정되기 때문임
        //변수를 사용해서 기능을 확장하려고 하면, 변수를 사용한 모든곳을 찾아가서
        //기능을 확장해줘야 함
        //관리포인트가 변수를 사용한 모든곳이 됨
        

        Mouse mouse = new Mouse();//마우스라는 설계도를 가지고 마우스를 만든거임
        mouse.ClickMouseLeft();
        mouse.ClickMouseRight();
        mouse.ScrollMouseWheel();
        mouse.PrintMouseBrand();

        //이전에는 Class라는 class에 마우스의 기능과 모니터의 기능이 정의되어 있었음
        //즉, Class가 모니터의 기능과 마우스의 기능을 관리하는 중이었음
        //하지만 이것을 Monitor라는 클래스, Mouse라는
        //클래스로 옮기니까, 더이상 Class는 Monitor와 Mouse의 구현이 어떻게 되어있는지 몰라도 됨
        //그냥 Monitor와 Mouse에 정의된 함수만 호출하는 기능을 함
        //또한, Monitor가 고장났다면 Monitor 클래스만 확인해보면 됨
        //이러한 특징을 "캡슐화"라고 함
    }
    
    //모니터를 출력하는 함수
 /*   void DisplayMonitor(int hz)
    {
        //144hz로 모니터 출력 시작! 출력
        Debug.Log(hz + "hz로 모니터 출력 시작!");
    }
    //모니터의 제조사를 출력하는 함수
    void PrintMonitorBrand(string brand)
    {
        //이 모니터의 브랜드는 삼성 입니다! 출력
        Debug.Log("이 모니터의 브랜드는 " +  brand + "입니다");
    }

    //마우스 좌클릭 함수
    void ClickMouseLeft()
    {
        Debug.Log("마우스 좌클릭 됨");
    }

    //마우스 우클릭 함수
    void ClickMouseRight()
    {
        Debug.Log("마우스 우클릭 됨");
    }

    //마우스 휠 움직였을때 사용할 함수
    void ScrollMouseWheel()
    {
        Debug.Log("마우스 휠 움직임");
    }

    //마우스의 브랜드를 출력하는 함수
    void PrintMouseBrand(string brand)
    {
        Debug.Log("이 마우스의 브랜드는 " + brand + "입니다.");
    }
 */
}

class Monitor//모니터 분류(class)
{
    //전역변수(Global Variable)(클래스 멤버변수 라고도 함)
    //지금까지 배운 지역변수로는 함수 밖에서 어떤 변수를
    //사용하려고 하면, 입력을 만들어서 처리하는 방식 밖엔 없었음
    //하지만, 클래스라는 개념이 도입되면서, 하나의 객체에 대한
    //정보를 모든 함수가 공유해야 하는 상황이 발생했음
    //그래서 전역변수를 만들어서 다른 함수에서 변수를 사용할 수 있도록 함
    private int monitorRate = 144;
    public string monitorBrand = "삼성";

    //monitor Brand라는 값을
    //변수가 아니라 함수로 가져오고 싶음
    //Getter/Setter 함수
    //멤버 변수의 값을 가져오거나 수정할때 사용하는 함수를 통상 Getter Setter라고 함
    public string GetMonitorBrand()
    {
        return monitorBrand;
    }
    //monitorBrand라는 값을 변수가 아니라 함수로 값을 바꾸고 싶음
    //출력 - X
    //입력 - 바꾸고 싶은 값을 받으면 될듯(string)

    public void SetMonitorBrand(string newMonitorBrand)
    {
        monitorBrand = newMonitorBrand;
    }

    //모니터를 출력하는 함수
    //접근 제한자
    //public, private, protected, internal
    //C#에서는 접근제한자가 없으면 기본값으로 private이 붙음
    public void DisplayMonitor()
    {
        //144hz로 모니터 출력 시작! 출력
        Debug.Log(monitorRate + "hz로 모니터 출력 시작!");
    }
    //모니터의 제조사를 출력하는 함수
    public void PrintMonitorBrand()
    {
        //이 모니터의 브랜드는 삼성 입니다! 출력
        Debug.Log("이 모니터의 브랜드는 " + monitorBrand + "입니다");
    }

}

class Mouse//마우스 분류(class)
{
    //전역변수
    string mouseBrand = "로지텍";
   
    //마우스 좌클릭 함수
    public void ClickMouseLeft()
    {
        Debug.Log("마우스 좌클릭 됨");
    }

    //마우스 우클릭 함수
    public void ClickMouseRight()
    {
        Debug.Log("마우스 우클릭 됨");
    }

    //마우스 휠 움직였을때 사용할 함수
    public void ScrollMouseWheel()
    {
        Debug.Log("마우스 휠 움직임");
    }

    //마우스의 브랜드를 출력하는 함수
    public void PrintMouseBrand()
    {
        Debug.Log("이 마우스의 브랜드는 " + mouseBrand + "입니다.");
    }
}
