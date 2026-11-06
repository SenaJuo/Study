using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    //Enemy가  Player 오브젝트를 따라가야 함
    /*
    1. Player의 위치가 필요함
    2. Player의 위치에서 내 위치를 빼면 됨
     */

    [SerializeField] private Transform playerTransform = null;
    [SerializeField] float moveSpeed = 0f;

    private void Update()
    {
        //Enemy 입장에서 목표의 좌표(벡터)를 알아야 함
        Vector3 destination = playerTransform.position - transform.position;
        float distance = destination.magnitude;

        Debug.Log(destination);

        //한 프레임에서, 연산이 너무 빨라서 5만큼 속도를 부여했는데,
        //Enemy의 속도도 너무 빠름
        //Time.deltaTime
        //하드웨어에 상관없이 일정한 주기가 보정이 됨
        Vector3 normalizedVector = destination.normalized;
        if(distance > 3)transform.position += normalizedVector * moveSpeed * Time.deltaTime;
    }
}
