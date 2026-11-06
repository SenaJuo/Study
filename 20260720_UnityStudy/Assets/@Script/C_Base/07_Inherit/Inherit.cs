using System.Globalization;
using UnityEngine;

public class Inherit : MonoBehaviour
{
    private void Start()
    {
        //클래스의 고급 기능
        //상속(Inherit)
        //Monitor, Mouse

        //Monitor
        //브랜드에 대한 정보
        //모니터의 이름에 대한 정보
        //자신의 브랜드를 출력하는 기능, 자신의 이름을 출력하는 기능

        //Mouse
        //브랜드에 대한 정보
        //마우스의 이름에 대한 정보
        //자신의 브랜드를 출력하는 기능, 자신의 이름을 출력하는 기능
        Monitor1 monitor = new Monitor1();
        monitor.PrintName();
        monitor.PrintBrand();

        Mouse1 mouse = new Mouse1();
        mouse.PrintName();
        mouse.PrintBrand();

        /*
         * 상속
         * 상속이란 클래스들끼리 공통되는 기능을
         * 모아둔 하나의 클래스를 만들고
         * 그 클래스의 기능들을 사용할 수 있게 하는 기능을 말함
         * 상속관계에서 공통되는 정보를 사용하려면
         * protected라는 접근제한자를 사용해야 함
         * 지금의 경우, Mouse와 Monitor의 공통 기능들을
         * Products라는 클래스에 모아둠
         * 이 과정을 추상화(Abstraction)이라고 함
         * 마우스와 모니터의 기능들을 포함하는 추상적인 개념을 찾는 과정임
         * 
         * 추상화*******
         */
    }
}
class Products
{
    protected string name = " ";
    protected string brand = " ";
    //앞에 접근제한자가 없으면 private임
    public void PrintName()
    {
        Debug.Log("제 이름은 : " + name + " 입니다.");
    }

    public void PrintBrand()
    {
        Debug.Log("브랜드는 : " + brand + " 입니다.");
    }
}

//Monitor1은 Products에 있는 기능을 확장해서 쓰겠다
class Monitor1 :Products
{
    public Monitor1()
    {
        //함수 호출은 되는데, 변수의 값이 출력이 안됨
        //각자의 클래스에서 변수에다가 값을 넣어주면 될거같음
        
        //이 클래스를 바탕으로 객체가 만들어지는 시점에 객체에 대한 정보를 넣어주면 될거 같음
        
        //생성자(Constructor)
        //객체가 생설될 떄, 반드시 한번 호출되는 함수
        
        name = "오디세이 G7";
        brand = "SAMSUNG";
    }
}

//Mouse1은 Products에 있는 기능을 확장해서 쓰겠다
class Mouse1 :Products
{
    public Mouse1()
    { 
        name = "지슈라2";
        brand = "로지텍";
    }
}