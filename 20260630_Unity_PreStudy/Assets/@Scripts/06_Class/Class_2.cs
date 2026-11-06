using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Class_2 : MonoBehaviour
{
 private void Start()
    {
        //아파트를 만들어 봄
        //아파트 설계도는 같고
        //101동과 102동을 만든다고 생각해봄
        //아파트에는 자기의 동수를 출력하는 기능이 있음
        //1. 이 아파트가 몇동인지에 대한 변수(정보)
        //2. 자신의 동수를 출력하는 함수
        Apartment101 apart101 = new Apartment101("101");
        Apartment101 apart102 = new Apartment101("102");
        Apartment101 apart103 = new Apartment101("103");
        Apartment101 apart104 = new Apartment101("104");
        Apartment101 apart105 = new Apartment101("105");
        Apartment101 apart106 = new Apartment101("106");
        Apartment101 apart107 = new Apartment101("107");
        Apartment101 apart108 = new Apartment101("108");
        Apartment101 apart109 = new Apartment101("109");
        apart101.PrintBuildingNumber();
        apart102.PrintBuildingNumber();
        apart103.PrintBuildingNumber();
        apart104.PrintBuildingNumber();
        apart105.PrintBuildingNumber();
        apart106.PrintBuildingNumber();
        apart107.PrintBuildingNumber();
        apart108.PrintBuildingNumber();
        apart109.PrintBuildingNumber();

        //객체를 생성했는데
        //생성자를 사용해서 별도의 함수 호출 없이
        //객체가 생성될 떄, 특정 기능을 수행하게 만들었음
        new Constructor(1);
        new Constructor(1, 2);
        
        

        //Apartment102 apart102 = new Apartment102();
        //apart102.PrintBuildingNumber();
    }
}

class Apartment101//101동에 대한 설계도
{
    //생성자
    //이 클래스를 바탕으로 객체가 만들어질때
    //반드시 한번 호출되는 함수 정도로 생각하면 됨
    //같은 class 정보(변수나, 함수)인데, 특정 정보만
    //다른 객체를 만들 떄 사용하면 좋음
    //ex) 아파트는 설계는 같지만, 동, 호수만 다름
    //ex2) 모든 플레이어의 설계는 같지만 닉네임만 다름
    //ex3) 모든 아이템의 설계는 같지만, 아이템의 이름만 다름
    public Apartment101(string buildingNumber) 
    {
        this.buildingNumber = buildingNumber;
    }

    private string buildingNumber = "";

    public void PrintBuildingNumber()
    {
        Debug.Log("--이 아파트는 " + buildingNumber+ "동 입니다.");
    }
}

/*class Apartment102//102동에 대한 설계도
{
    private string buildingNumber = "102";

    public void PrintBuildingNumber()
    {
        Debug.Log("이 아파트는 " + buildingNumber + "동 입니다.");
    }
}*/

class Constructor//생성자
{
     //이 클래스를 바탕으로 객체가 생성될 때
     //객체 생성됨! 이라는 문구를 띄우고 싶음
     
    //생성자도 함수처럼 오버로딩(overloading)이 가능함
     public Constructor(int value)
    {
        Debug.Log("객체 생성됨" + value);
    }

    public Constructor(int value1,  int value2)
    {
        Debug.Log("객체 생성됨" + (value1 + value2));
    }
}