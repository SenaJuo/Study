using UnityEngine;

public class Vector : MonoBehaviour
{
    /*
    벡터(Vector)
    힘과 방향을 가진 수
    수의 집합
    3D를 만들때는 3차원 벡터를 사용함
    Vector3 라는 구조체를 만들어둠
    벡터는 힘과 방향만 같으면 같은 벡터로 취급함
    */

    
    private void Start()
    {
        Vector3 vector1 = new Vector3(2f, 2f, 0f);    
        Vector3 vector2 = new Vector3(2f, 0f, 0f);
        Vector3 addVector = vector1 + vector2;
        Debug.Log(addVector);

        /*벡터의 뺄셈
         * 벡터의 뺄셈도 덧셈과 마찬가지로
         * 같은 성분끼리 빼주면 되는데, 달라지는건 방향
         * A-B를 연산하면 결과로 나오는 벡터는 A를 바라보는 벡터가 됨
         * 마찬가지로 B-A를 하면 결과로 나오는 벡터는 B를 바라보는 벡터가 됨
        */

        Vector3 vector3 = new Vector3(5f, 3f, 0f);
        Vector3 vector4 = new Vector3(1f, 2f, 0f);
        Debug.Log(vector3 - vector4);

        //방향벡터(단위벡터)
        //만약 5라는 벡터가 있음
        //근데 같은 방향으로 2만큼 전진하고 싶음
        //그때, 쉽게 할 수 있는 방법이 5라는 벡터를 5등분해서 한칸을 구하고, 그 한칸에다가 2를 곱하는 방식이 있음
        //5라는 벡터를 5등분해서 1칸으로 만드는데,
        //그 한칸을 방향만 가진 방향벡터 또는 단위벡터라고 부름

        /*  스칼라
         * 벡터의 힘
         * 벡터가 가지고 있는 크기를 말함 (방향은 제외)
         * 만약 (3, 0), (0, 4) 라는 벡터가 있을 떄
         * 이 두개를 합쳐서 나오는 벡터의 크기를 구한다고 했을때,
         * 구하는 방식은 피타고라스의 정의를 사용해서 
         * 5라는 크기를 구할 수가 있음(제곱근)
         * (3,0), (4,0) 라는 벡터를 합성하면 (3, 4)라는 벡터가 나오는데,
         * 이녀석의 크기가 5라는걸 알고 있으니
         * 특정 벡터의 크기를 구하려면 모든 요소를 제곱해서
         * 제곱근한 결과가 된다 라는걸 알 수 있음
         */

      

        Vector3 vector5 = new Vector3(3f, 0f, 0f);
        Vector3 vector6 = new Vector3(0f, 4f, 0f);
        Vector3 vector7 = vector5 + vector6;
        //Vector3.Magnitude
        //각 성분을 제곱하고 더해서 크기를 구해주는 기능
        Debug.Log(vector7.magnitude);

        Vector3 vector8 = new Vector3(1f,0f,0f);
        Vector3 vector9 = new Vector3(0f,1f,0f);
        Vector3 vector10 = vector8 + vector9;
        float force = vector10.magnitude;
        Debug.Log(force);
         
        
        /*벡터의 정규화
         * 플레이어가 W를 눌렀을때는 0,1로 움직이고
         * 플레이어가 D를 눌렀을때는 1,0으로 움직일때
         * W와 D를 동시에 누르면, 플레이어는 벡터의 합과 크기를 구하는 공식에 의해서 루트2라는 크기를 가지게 됨 (루트(1^2 + 1^2))
         * 루트 2는 1보다 약 1.414배 큼
         * 플레이어가 WD를 누르더니 1.4배 빠르게 이동함
         * 이런걸 막기 위해서 방향만 놔두고 크기를 1인 벡터를 만드는 과정이 필요함
         * 이 과정을 정규화(Normalization)이라고 함
         * 즉, 어떤 벡터를 단위벡터로 만드는 과정을 말함
         */
        //Vector3.normalized : 정규화 해줌 
        Vector3 normalizedVector = vector10.normalized;
        Debug.Log(normalizedVector);
        Debug.Log(normalizedVector.magnitude);
        

    }
}
