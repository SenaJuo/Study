using UnityEngine;
namespace CoordinateSystem { 
    public class Child : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;

       private void Update()
       {
        //    transform.position += new Vector3(1f, 0f, 0f) * moveSpeed * Time.deltaTime;na
        transform.localPosition += new Vector3(0f, 0f, 1f) * moveSpeed* Time.deltaTime;
            /*월드 좌표 기준으로 z축 방향으로 움직이면,
             * Child는 앞쪽으로 이동했음
             * 로컬좌표 기준으로 z축 방향으로 움직이면, 부모의 좌표계를 기준으로 움직이기 때문에
             * Parent의 z축 방향이 아래쪽을 향하고 있어서
             * Child도 아래쪽으로 움직이게 됨
             * 
             * 
             * (왠만하면 대부분 월드 좌표 기준으로 해결이 됨)
             */
       }


    }
}