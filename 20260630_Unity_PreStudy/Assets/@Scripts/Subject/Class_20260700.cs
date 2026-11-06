using UnityEngine;

//class -> 어떤 작은 물건을 만들기 위한 설계도
//class -> 분류
//class에는 같은 분류의 정보들이 들어가있음 -> 변수
//class에는 특정 기능이 있어야 함 -> 함수(기능)
//-> class는 같은 속성을 가진 변수와 함수의 집합
/*엔진이라는 분류
 * Engine이라는 이름을 가진 class
 * Engine이라는 class에는 Engine을 구성하는 정보와 엔진의 기능이 정의되어 있음
 * Engine을 구성하는 변수와 함수가 존재한다
 * 
 * class안에 존재하는 변수와 함수를 멤버 변수, 멤버 함수 라고 함
 **/
/*public class Class_20260700 : MonoBehaviour
{
    private void Start()
    {
        Player player = new Player();
        player.AttackDamage();
        player.HpHeal();
        player.GetPlayerName();

        Enemy enemy = new Enemy();
        enemy.AttackDamageOfEnemy();
        enemy.GetEnemyName();
        enemy.GetScoreFromEnemy();
    }

}


class Player
{
    string playerName = ("공백");
    public void AttackDamage()
    {
        Debug.Log("공격");
    }

    public void HpHeal()
    {
        Debug.Log("회복");
    }

    public void GetPlayerName()
    {
        Debug.Log("플레이어 이름 : " + playerName);
    }
}

class Enemy
{
    string enemyName = ("짱쎈 몬스터");
    int scoreFromEnemy = 80;
    public void AttackDamageOfEnemy()
    {
        Debug.Log("적이 공격");
    }

    public void GetEnemyName()
    {
        Debug.Log("적의 이름 : " + enemyName);
    }

    public void GetScoreFromEnemy()
    {
        Debug.Log("적으로 부터 얻는 점수 : " + scoreFromEnemy);
    }
}*/



public class Class_20260700 : MonoBehaviour
{
    private void Start()
    {
        Player player = new Player();
        Enemy enemy = new Enemy();

        player.Attack();
        player.Heal(10f);
        player.PrintHp();
        player.PrintName();
        player.AddScore(enemy.GetScore());//적을 처치했다고 가정
        Debug.Log(player.GetCurrentScore());

        enemy.Attack();
        enemy.PrintName();
        Debug.Log(enemy.GetScore());
    }
}

class Player
{
    private float currentHp = 80f;
    private float maxHp = 100f;
    private string playerName = "정의로운 용사";
    private float currentScore = 0f;

    public void Attack()
    {
        Debug.Log("Player 공격함!");
    }

    public void Heal(float _amount)
    {
        Debug.Log("Player 체력 회복");

        float healedHp = currentHp + _amount;// 일단 먼저 체력 더해보고, 최대 체력 이상이면 최대체력으로 맞춤

        if (healedHp > maxHp)
        {
            currentHp = maxHp;
        }
        else
        {
            currentHp = healedHp;
        }
    }

    public void PrintHp()
    {
        Debug.Log("Player의 현재 체력 : " + currentHp);
    }

    public void PrintName()
    {
        Debug.Log("Player의 이름 : " + playerName);
    }

    public void AddScore(float _score)
    {
        currentScore += _score;
    }

    public float GetCurrentScore()
    {
        return currentScore;
    }
}

class Enemy
{
    private string enemyName = "악당";
    private float score = 100f;
    public void Attack()
    {
        Debug.Log("Enemy 공격함!");
    }

    public void PrintName()
    {
        Debug.Log("Enemy의 이름 : " + enemyName);
    }

    public float GetScore()
    {
        return score;
    }
}
