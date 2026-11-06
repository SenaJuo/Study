using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCouroutine : MonoBehaviour
{
    //동기식 진행 방식
    //synchronous

    //비동기식 진행 방식
    //asynchronous

    //Coroutine 비동기식 진행방식을 할 수 있도록
    //만들어진 문법

    //Dictionary라는 자료구조가 있음
    private Dictionary<float, WaitForSeconds> waitForSecondsCashe = null;
    private WaitForSeconds waitForOneSeconds = null;

    private void Awake()
    {
        waitForOneSeconds = new WaitForSeconds(1f);
    }
    private void Start()
    {
        //코루틴은 일반 함수를 호출하는 식으로 호출하면 안됨
        //StartCoroutine() 함수를 사용해야 함
        //StartCoroutine(CoSomeCoroutine());
        //StartCoroutine(CoFixedUpdateCoroutine());
        //StartCoroutine(CoLateUpdateCoroutine());
        //StartCoroutine(CoWaitSeconds());
        StartCoroutine(CoSomeWork(SomeWork1));
    }

    //함수형식으로 만듦(특정 기능을 수행해야 하니까)

    //IEnumerator는 작업단위를 반환함
    //yield return을 만나기 전까지의 코드블럭을 하나의 작업단위로 좀
    //StartCoroutine으로 작업단위를 쪼개서, 하나씩 실행하게 만듦
    //yield return 다음에 얼마나 작업을 쉴지를 결정할 수 있음
    private IEnumerator CoSomeCoroutine()
    {
        //Coroutine을 Update처럼 활요할 수 있는 방법임
        //Update는 MonoBehaviour를 상속받는 클래스에 단 하나만 존재할 수 있게 되어있음
        //그래서 Update에서는 매프레임 작업되는 모든 로직들이 정의되어 있어야 함
        //또한, 종료시점을 정할 수 있는 방법없음
        //그래서 Update를 안쓰더라도 계속 호출은 일어남
        //Coroutine은 위 문제들을 해결할 수 있는 좋은 해결책임
        while (true)
        {
            Debug.Log("Coroutine 실행됨");
            //IEnumerator는 작업단위를 반환
            //그렇기 때문에 yield return을 사용함
            yield return null; // 한 프레임만 쉼
        }
    }

    private IEnumerator CoFixedUpdateCoroutine()
    {
        while (true)
        {
            Debug.Log("Fixed Update Coroutine");
            //IEnumerator는 작업단위를 반환
            //그렇기 때문에 yield return을 사용함
            yield return new WaitForFixedUpdate(); // 한 프레임만 쉼
        }
    }

    private IEnumerator CoLateUpdateCoroutine()
    {
        while (true)
        {
            yield return null; // 한 프레임만 쉼
            Debug.Log("LateUpdateCoroutine");
            //IEnumerator는 작업단위를 반환
            //그렇기 때문에 yield return을 사용함
        }
    }
    //1초쉬고 다른 행동하기
    //몇초쉬고 다른 행동하기

    private IEnumerator CoWaitSeconds()
    {
        //1,2,3,4를 1초 간격으로 찍고싶음
        while (true)
        {
            Debug.Log("1..");
            yield return waitForOneSeconds;
            Debug.Log("2..");
            yield return waitForOneSeconds;
            Debug.Log("3..");
            yield return waitForOneSeconds;
            Debug.Log("4..");
            yield return Cowait5Seconds();
        }
    }

    private IEnumerator Cowait5Seconds()
    {
        yield return new WaitForSeconds(5f);
    }

    //비동기의 문제점은 작업이 끝나는 타이밍을 잡기가 힘듦
    private IEnumerator CoSomeWork(Action<float> _onWorkEndAction)
    {
        Debug.Log("작업 시작");
        yield return new WaitForSeconds(3f);

        Debug.Log("작업 끝");
        //여기에 다른 함수가 들어오면 됨
        _onWorkEndAction?.Invoke(100f);
        
    }
    private void SomeWork()
    {
        Debug.Log("SomeWork 시작");
    }

    private void SomeWork1(float _someWork1)
    {
        Debug.Log("SomeWork1 시작");
        Debug.Log(_someWork1);
    }
}
