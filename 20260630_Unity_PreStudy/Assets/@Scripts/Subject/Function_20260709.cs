using UnityEngine;

public class Function_20260709 : MonoBehaviour
{

   private void Start()
    {
        
                int s = 120; //점수

                score(s);
                grade(s);
                multiple(s);


                static void score(int a)
                {
                    Debug.Log("학생의 점수는 " + a); //점수 출력
                }

                static void grade(int a) //점수에 따라 등급 출력
                {
                    if (a >= 0 && a <= 100) //점수의 범위는 0~100
                    {
                        if (a > 95)
                        {
                            Debug.Log("A");
                        }
                        else if (a > 90)
                        {
                            Debug.Log("B");
                        }
                        else if (a > 85)
                        {
                            Debug.Log("C");
                        }
                        else if (a > 80)
                        {
                            Debug.Log("D");
                        }
                        else
                        {
                            Debug.Log("F");
                        }
                    }
                    else
                    {
                        Debug.Log("점수 범위 오류"); //0~100사이의 점수가 아닌 값이 입력된 경우 문구 출력
                    }
                }


                static void multiple(int a) //입력 받은 점수가 3의 배수인지 아닌지
                {
                    if (a >= 0 && a <= 100) // 입력 받은 점수가 0~100사이 일때만 
                    {
                        if (a % 3 == 0) //3의 배수인지 아닌지 판단
                        {
                            Debug.Log(a + "은 3의 배수입니다."); //출력
                        }
                    }
                }
    }

}