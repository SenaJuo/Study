using UnityEngine;

public class DataStructure : MonoBehaviour
{
    //patrol 구역이 있는데
    //1, 2, 3, 4 구역을 순찰해야 함
    //구역에 대한 정보를 저장하고 싶음
    private int patrol1 = 1;
    private int patrol2 = 2;
    private int patrol3 = 3;
    private int patrol4 = 4;

    private int[] patrolArray = { 1, 2, 3, 4 };

    private void Start()
    {
        Debug.Log(patrolArray[0]);
        Debug.Log(patrolArray[1]);
        Debug.Log(patrolArray[2]);
        Debug.Log(patrolArray[3]);

        for(int i =0; i<4; ++i)
        {
            Debug.Log(patrolArray[i]);
        }
    }

}
