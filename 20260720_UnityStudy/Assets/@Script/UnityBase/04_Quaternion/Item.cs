using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]private float rotationSpeed = 5f;

    private void Update()
    {
        //Y축으로, 매 프레임 rotationSpeed만큼 회전을 시키고
        //Y축의 값이 rotationSpeed인 회전값을 
        //지금 object의 roatation에다가 계속 합성을 해주는 식으로 구현

        UnityEngine.Quaternion rotation = UnityEngine.Quaternion.Euler(new Vector3(0f, rotationSpeed, 0f));
        transform.rotation *= UnityEngine.Quaternion.Euler(rotation.eulerAngles*Time.deltaTime);
        /*
         * Quaternion을 사용할 때는
         * 부모 object의 scale이 반드시 1, 1, 1이 되어야 함
         * Quaternion의 내부 행령 연산 때문에, 부모 object의 크기가
         * 1, 1, 1이 아니면, 자식 object를 돌릴 때 도형이 깨지는 현상이 발생함
         */
    }

}
