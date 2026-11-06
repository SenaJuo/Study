using Unity.Mathematics;
using UnityEngine;

public class Quaternion : MonoBehaviour
{
    private void Start()
    {
        //transform.rotation = UnityEngine.Quaternion.Euler(new Vector3(0f, 90f, 0f));

        /*
         유니티에서 회전을 표현하는 방법
         Transform 컴포넌트를 확인해보면, Rotation도
         Position과 마찬가디로 3가지 수의 집합처럼 보임
         그래서 Vector3를 사용하면 될 것 처럼 보이지만, 사실 그렇지 않음
         3가지 각도를 표현하는 방식의 문제점은,
         회전을 하다보면 2개 이상의 축이 하나로 합쳐지는 문제점이 발생함 (짐벌락 현상)
         이러한 각도 표현을 EulerAngle이라고 함
         그래서 유니티에서는 이러한 현상을 해결하기 위해,
         X, Y, Z 축과 더불어 W축을 하나 더 넣은 Quaternion이라는 각도 표현 방식을 사용함
         */

        UnityEngine.Quaternion rotation1 = UnityEngine.Quaternion.Euler(new Vector3(0f, 90f, 0f));
        UnityEngine.Quaternion rotation2 = UnityEngine.Quaternion.Euler(new Vector3(90f, 0f, 0f));

        UnityEngine.Quaternion rotation3 = rotation1 * rotation2;
        Debug.Log(rotation3.eulerAngles);
        //transform.rotation = rotation3;

        /*
         Position을 다룰때는, Vector3 구조체를 더하는 방식으로 합성을 했음
         Rotation을 다룰때는, Quaternion으로 표현된 회전값을 곱하는 형식으로 합성을 함.
         Quarternion안에 내부적으로 연산되는 행렬연산 때문에 곱하기를 사용함
         */
    }
}