using UnityEngine;


public class Class_3 : MonoBehaviour
{
    private void Start()
    {
        //상속
        //객체지향의 꽃

        //모니터, 마우스
        //모니터는 "저는 삼성 제품 입니다." 출력
        //마우스는 "저는 삼성 제품 입니다." 출력
        Monitor1 monitor = new Monitor1();
        Mouse1 mouse = new Mouse1();

        monitor.PrintBrand();
        mouse.PrintBrand();

        /*추상화
        //강아지랑 고양이 
        //둘 다 먹는 행동을 함
        강아지와 고양이에게 상속시킬 클래스를 만드려고 고민중에
        강아지와 고양이를 모두 만족시키는 범주를 찾아야 함
        동물 이라고 할 수 있을거 같음
        드래서 Animal이라는 클래스를 만들어서 상속시킴
        더 넓은 범주로 보면 생명체, 유기체 까지도 갈 수 있을거 같음
        모든 class를 추상화하는건 인간이 할 수 없기 때문에
        각자 만들고 싶은 게임 기획에서 관리포인트를 줄이는 방향으로 상속 설계를 하면 됨
        */


        //동물한테 이름을 부여하고 싶음
        Dog dog = new Dog();
        Cat cat = new Cat();
        dog.Eat();
        cat.Eat();
        //고양이랑, 강아지가 짖을거임
        //고양이는 뭐라고 소리를 낼까요? >> 공통으로 사용할 거임
        //고양이는 야옹~! >> 각자 클래스에서 정의

        //강아지는 뭐라고 소리를 낼까요? >> 공통으로 사용할 거임
        //강아지는 왈~! >> 각자 클래스에서 정의
        dog.MakeSound();
        cat.MakeSound();
        dog.Howling();
        cat.Growling();
        //이번에는 Animal에 포함되는 기능이 아니라
        //강아지랑, 고양이랑 각각 고유의 기능을 넣어봄
        //강아지는 하울링
        //고양이는 그롤링

        //다형성
        //자식이 생성될 때 부모의 형태로 생성을 할 수 있음  
        Dog dog2 = new Dog();
        Cat cat2 = new Cat();
        Animal dog3 = new Dog();
        Animal cat3 = new Cat();

        //부묘형태로 자식을 생성하면
        //결국 타입은 부모의 타입이기 때문에
        //부모에 있는 함수만 실행이 됨
        //하지만, 부모의 가상함수를 상속받아서 Dog나 Cat의 재정의 할 수 있기 때문에
        //부모의 함수를 호출했을떄, Dog나 Cat이 정의한 함수가 호출됨
        

        //객체지향의 특징 >>  다향성 캡슐화 상속
    }
}
class Animal
{
    //protected
    //Animal을 상속받는 녀석들만 쓸 수 있도록
    //해주는 접근 제한자임
    //상속받은 녀석 외에 외부에서는 호출 안됨
    protected string animalType="";
    public void Eat()
    {
        Debug.Log(animalType + " 밥 먹는 중....");
    }

    public virtual void MakeSound()
    {
        Debug.Log(animalType+"는 뭐라고 소리를 낼까요?");
        //강아지의 행동
        //고양이의 행동
    }
}
class Dog:Animal
{
 //   private string animalType = "강아지";
 //   public void Eat()
 //   {
 //       Debug.Log("밥 먹는 중....");
 //   }
 public Dog()
    {
        animalType = "강아지";
    }
    //강아지에서는 MakeSound를 쓰긴 쓸건데
    //그 밑에 한줄만 더 추가하고 싶음
    //강아지는 왈~! 이라는 내용을 추가하고 싶음
    //근데, MakeSound 함수를 다시 만들어버리면
    //Animal에 있는 MakeSound랑 겹침
    //>>Animal에 있는 가상 함수를 확장할거임
    //overriding(오버라이딩)

    //override가 붙음 함수는
    //부모 클래스에 있는 virtual이 붙어있는 함수를 재정의한다.
    public override void MakeSound()
    {
        //밑에있는 로그가 찍히기 전에
        //Animal의 MakeSound()기능이 있었으면 좋겠음
        //Dog하는 class에서 Animal의 함수를 호출을 해줘야함
        base.MakeSound();
        Debug.Log("강아지는 왈~!"); 
    }

    public void Howling()
    {
        Debug.Log("하울링~");
    }
}

class Cat:Animal
{
    public Cat()
    {
        animalType = "고양이";
    }
    //private string animalType = "고양이";
    //   public void Eat()
    //    {
    ///      Debug.Log("밥 먹는 중....");
    //  }
    public override void MakeSound()
    {
        base.MakeSound();
        Debug.Log("고양이는 야옹~!");
    }
    public void Growling()
    {
        Debug.Log("그롤링~");
    }
}

class SamsungProduct
{
    public void PrintBrand()
    {
        Debug.Log("저는 삼성 제품 입니다.");
    }
}

/*
 * 상속(Inheritance)
 * Monitor와 Mouse를 만들때, PrintBrand()라는 기능이 완전 똑같았음
 * 해당 기능을 SamsungProduct라는 클래스를 만든 후 SamsungProduct에 한번 정의하고
 * Monitor와 Mouse에 SamsungProduct를 상속시켜서 사용하면,
 * Monitor와 Mouse에 PrintBrand()의 정의가 없어도 해당 기능을 사용할 수 있게 됨
 * C# script를 만들면 자동으로 Monobehaviour를 상속 받게 됨
 * 유니티가 게임엔진을 돌리기 위한 기능들을 사용자가 구현할 필요 없이,
 * Monobehaviour에 있는 기능을 사용할 수 있도록 한것임
 */

class Monitor1 : SamsungProduct
{
    //public void PrintBrand()
    //{
    //    Debug.Log("저는 삼성 제품 입니다.");
    //}
    
}

class Mouse1 : SamsungProduct
{
    //public void PrintBrand()
    //{
    //   Debug.Log("저는 삼성 제품 입니다.");
    //}
}