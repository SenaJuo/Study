using UnityEngine;

public class Condition_20260707 : MonoBehaviour
{
    private void Start()
    {
        /*
         *1. 변수 네이밍 규칙
         * - 변수에는 띄어쓰기가 안됨
         * - Camel Case, Snake Case, Pascal Case
         * - Camel Case(띄어쓰기 대신에 다음 영문 앞글자를 대문자로 만들어주는 방식)
         * - isMultipleOfThree
         * - Snake Case(띄어쓰기 대신에 _를 넣음)
         * - is_multiple_of_three
         * - Pascal Case(CamelCase와 같은데 맨처음 앞글자도 대문자)
         * - IsMultipleOfThree
         * 
         * C# 코딩 컨벤션
         * Camel Case - 멤버 변수, 지역변수, 
         * Pascal Case - 클래스명, 함수명
         */


        // 과제 1
        // 성적처리기
        // 내가 받은 성적이 있고 거기에 따라서
        // A,B,C,D,F, 라는 성적이 부여
        // 성적은 0 ~ 100점 까지 존재함
        // 100포함~95미포함 까지 A
        // 95    ~ 90 B
        // 90    ~ 85 C
        // 85    ~ 80 D
        // 그 외에 점수는 F

        // 마지막에 그 성적이 3의 배수인지 아닌지 출력해보세요

        //출력예시 : 
        //98점을 받은 학생의 점수는 A입니다.
        //98은 3의 배수가 아닙니다.
        Debug.Log("성적처리기");

        //과제 : 함수를 사용해서 성적처리기 만들기, 등급판별 기능, 3의 배수인지 아닌지 기능, 출력하는 기능 << 함수 3개를 만들어서 작성하기

        //성적판별

        //int score = 87;//점수저장변수


        /*   if(score <=100 && score > 95)//96~100점
           {
               Debug.Log(score+"점을 받은 학생의 점수는 A입니다.");
           }
           else if(score > 90)//91~95점
           {
               Debug.Log(score + "점을 받은 학생의 점수는 B입니다.");
           }
           else if (score > 85)//86~90점
           {
               Debug.Log(score + "점을 받은 학생의 점수는 C입니다.");
           }
           else if (score > 80)//81~85점
           {
               Debug.Log(score + "점을 받은 학생의 점수는 D입니다.");
           }
           else if( score >=0)//0~80점
           {
               Debug.Log(score + "점을 받은 학생의 점수는 F입니다.");
           }
           else
           {
               Debug.Log("점수입력오류");//0~100점 이외의 점수가 입력됐을경우
           }

            //3의 배수 여부 출력
           if(score>=0 && score <= 100)  //0~100사이의 점수만 입력됐을경우 출력
           { 
               if (score%3==0)//3으로 나누었을때 나머지가 0
               {
                   Debug.Log(score + "점은 3의 배수입니다.");
               }
               else
               {
                   Debug.Log(score + "점은 3의 배수가 아닙니다.");
               }
           }
           else//0~100점 이외의 점수가 입력됐을경우
           {
               Debug.Log("점수입력오류");
           }
        */


        //--------------------------------------------------------------------------------------풀이


        int score = 96;
        //원칙 : 관리포인트를 줄이는 방향으로 함수 설계
        StartScoreCalculate(score);

       
    }
        
    //요구사항을 수행하는 기능
    //StartScoreCalculate()
    //입력 - 점수만 받으면 됨
    //출력 - 없음

    void StartScoreCalculate(int score)
    {
        char level = GetGrade(score);
        PrintStudentInfo(score, level);

        bool isMultiple = IsMultipleOfThree(score);
        PrintIsMultipleOfThree(isMultiple, score);
    }

    //1.받은 성적을 바탕으로 등급을 매기는 기능
    //입력 -> int형의 받은 성적을 넣어줘야 함
    //출력 -> char형의 등급을 출력으로 내주면 될듯
    char GetGrade(int score)
        {
            char result = ' ';
            if (score >= 0 && score <= 100)
            {
                if (score > 95)
                {
                    result = 'A';
                }
                else if (score > 90)
                {
                    result = 'B';
                }
                else if (score > 85)
                {
                    result = 'C';
                }
                else if (score > 80)
                {
                    result = 'D';
                }
                else
                {
                    result = 'F';
                }
            }
                return result;

        }
        // 2. 3의 배수인지 아닌지를 판별하는 기능
        // 3의 배수인지 아닌지를 판별하는 기능
        // 출력 -> 인지 아닌지(true인지 false인지 를 풀력할 수 있도록 bool값
        // 입력 -> int형의 점수를 입력으로 하면 됨
        bool IsMultipleOfThree(int score)
        {   
            //지역 변수(local variables)
            //함수를 호출하거나, 반복문을 돌릴 떄, 변수가 필요한 경우가 있음
            //변수를 만든다는것은 컴퓨터의 메모리에 일정한
            //공간을 점유한다는것을 뜻함
            //이 변수들이 함수가 호출될때마다 지워지지않고
            //계속 자리를 차지하게 되면, 결국에는 메모리의
            //모든 공간을 차지하게 되어, 메모리가 터짐
            //즉, 메모리를 효율적으로 쓰지 못한다는 거임
            //따라서, 변수에 자동으로 사라지도록 생명주기 라는것을 부여함
            //보통 중괄호 안에서 선언된 변수들은
            //중괄호가 끝나면 사라지도록 되어있음
            bool result = false;
            if (score % 3 == 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
    }

        //학생의 점수와 등급을 출력해주는 함수를 만들거임
        //입력 - int형 점수, char형 등급
        //출력 - 없음(Debug.Log만 수행하고 다른 결과를 받을 필요가 없음)
        void PrintStudentInfo(int score, char grade)
        {
            Debug.Log(score + "를 받은 학생의 등급은 : " + grade);
        }

        //3의 배수 인지 아닌지에 대한 정보를 받아서
        //로그를 출력해주는 함수
        //입력 - bool형(IsMultipleOfThree의 결과)
        //출력 - 없음
        void PrintIsMultipleOfThree(bool isMultiple, int score)
        {
            if (isMultiple)
            {
                Debug.Log(score + "는 3의 배수 입니다.");
            }
            else
            {
                Debug.Log(score + "는 3의 배수가 아닙니다.");
            }
        }
    }

