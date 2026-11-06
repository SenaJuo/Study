using UnityEngine;
namespace CoordinateSystem 
{ 
    public class Parent : MonoBehaviour
    {

        //SerializeField를 사용해서 변수의 값을 바꾸면 무조건 Inspector에 있는 값을 기준으로 돌아감
        [SerializeField]private float moveSpeed = 5f;
        //private void Update()
        //{
        //    //월드 좌표계 기준으로 Z축으로 이동하는 코드
        //    transform.position += new Vector3(0f, 0f, 1f) * moveSpeed * Time.deltaTime;
        //}
    }
}