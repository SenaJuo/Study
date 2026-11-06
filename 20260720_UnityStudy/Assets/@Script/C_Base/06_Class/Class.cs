using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class Class : MonoBehaviour
{
    private void Start()
    {
        //Class 객체지향 프로그래밍
        /*원시 프로그래밍 언어들은
         * 특정함수가 함수들을 호출하면서 기능을 동작시킴
         * 하지만, 프로그램이 복잡해지면서, 함수가 함수를
         * 계속 호출 하는 방식은 너무 큰 복잡성을 띄게 됨
         * (뮤조건 단방향이라, 모든 기능들을 순차적으로 사용해야 했기 때문)
         * 해당 문제를 해결하기 위해서, 프로그램을 사물의 단위에서 바라보자 라는 철학이 생기게 됨
         * 그것이 객체지향 프로그래밍(Object Oriented Programming)의 발단임
         * 
         * 객체단위 또는 사물단위로 생각해야 함
         * 사람의 손을 예시로 들었을 때
         * 이 손을 만들기 위해서 필요한 정보들이 있음
         * 손가락 갯수, 손톱의 위치, 핏줄의 갯수, 손의 색상 등등,,
         * 설계도 -> class
         * 설계도를 바탕으로 만들어진 객체 또는 물체를 -> Instance 라고 부름
         * 
         * class -> 분류(한국어로 직역)
         * Monitor, Mouse에 대한 기능과 정보를 만들어 보고, 각각 분류해봅시다.
         * 
         * Monitor, Mouse
         * Monitor에는 주사율 관련된 정보, 브랜드의 정보, 주사율을 출력하는 기능, 브랜드명을 출력하는 기능
         * 
         * Mouse에는 마우스 무게에 대한 정보, 브랜드의 정보, 무게를 출력하는 기능, 브랜드명을 출력하는 기능
         */

        //모니터

        //monitor.PrintMonitorHz(); //주사율
        //PrintMonitorBrand(brand);//브랜드
        ////마우스

        //PrintMouseWeight(weight);//무게
        //PrintMouseBrand(mouseBrand);//브랜드

        /*Monitor와 Mouse의 분류를 만들었음
         * Monitor와 Mouse의 설계도를 만듬
         * 만들어진 설계도를 바탕으로 모니터 한대랑, 마우스 한개를 실제로 만들어 볼거임
         * (class를 바탕으로 instance를 만드는 과정임)
         */

        /*Monitor의 설계도를 바탕으로
         * Monitor 객체를 만들고, 그 객체를 다루기 위해서 Monitor 형태의 monitor하는 변수에 저장해봄
         */
        Monitor monitor = new Monitor();
        //멤버 접근 연산자
        // '.'
        //.을 쓰게 되면, 객체가 가지고 있는 기능들에 접근을 할 수 있음
        //접근 제한자
        //public, protected, private, internal
        monitor.PrintMonitorHz();
        monitor.PrintMonitorBrand();
        
        Mouse mouse = new Mouse();
        mouse.PrintMouseWeight();
        mouse.PrintMouseBrand();

        //힙 메모리를 청소 >> Garbage Collector(GC)   
    }
}

class Monitor
{
    string hz = "144hz";
    string brand = "SAMSUNG";
    public void PrintMonitorHz()
    {
        Debug.Log("모니터의 주사율 : " + hz);
    }

    public void PrintMonitorBrand()
    {
        Debug.Log("모니터의 브랜드 : " + brand);
    }
}

class Mouse
{
    int weight = 100;
    string mouseBrand = "LG";
    public void PrintMouseWeight()
    {
        Debug.Log("마우스 무게 : " + weight);
    }

    public void PrintMouseBrand()
    {
        Debug.Log("마우스의 브랜드 : " + mouseBrand);
    }
}