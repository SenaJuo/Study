using UnityEngine;

/*
 플레이어1과 2가 있음
플레이어 1은 전사, 플레이어2는 마법사
적은 단일 몬스터로 보스라는 이름을 가짐
보스의 체력이 0이 될때까지 보스와 플레이어1과 2가 서로 공격을 함
공격받고 나서 플레이어1과 2는 자신들의 공격력의 10%에 해당하는 수치를 체력회복
 */

public class PersonalStudy : MonoBehaviour
{
    private void Start()
    {
        Player1 player1 = new Player1();
        Player2 player2 = new Player2();
        Enemy enemy = new Enemy();

        player1.PlayerStat(); //플레이어1의 정보 출력
        player2.PlayerStat(); //플레이어2의 정보 출력
        enemy.EnemyStat(); //적 정보 출력

        while (enemy.EnemyHp() > 0) //몬스터의 체력이 0이 되기 전까지 반복
        {
            player1.PlayerCastSkill();//플레이어1 스킬 발동
            enemy.EnemeyCurrentHp(player1.GetAttackDamage());//플레이어1으로 부터 공격받고 난 후의 적의 체력
            player1.Heal(player1.PlayerHeal());//플레이어1 체력회복
            player2.PlayerCastSkill();//플레이어2 스킬 발동
            enemy.EnemeyCurrentHp(player2.GetAttackDamage());//플레이어2로 부터 공격받고 난 후의 적의 체력
            player2.Heal(player2.PlayerHeal());//플레이어2 체력회복
            
            if (enemy.EnemyHp() == 0)//보스의 체력이 0이 되면 더 이상 적이 플레이어를 공격을 못하게 종료
            {
                Debug.Log("보스 사망");
                break;
            }

            enemy.EnemyCastSkill();//적 공격
            player1.PlayerCurrentHp(enemy.GetEnemyAttackDamage());//공격받고 난 후의 플레이어1 체력
            player2.PlayerCurrentHp(enemy.GetEnemyAttackDamage());//공격받고 난 후의 플레이어2 체력
        }
    }
}

class Player // 플레이어 공통
{
    protected string playerName = "";
    protected string playerJob = "";
    protected string playerSkill = "";
    protected float playerAttackDamage;
    protected float playerMaxHp;
    protected float currentHp;
    
    public void PlayerStat() //플레이어 스탯
    {
        Debug.Log("이름 : " +  playerName + ", 직업 : " + playerJob + "\n" + "공격력 : " + playerAttackDamage + ", 기본체력 : " + playerMaxHp);
    }
    public void PlayerCastSkill()
    {
        Debug.Log(playerName + " " + playerSkill + "발동");
    }
    public float GetAttackDamage() //플레이어의 공격력 저장
    {
        return playerAttackDamage;
    }
    public void PlayerCurrentHp(float _enemyAttackDamage) //플레이어의 체력(몬스터에게 공격받고 난 후의 체력)
    {
        currentHp -= _enemyAttackDamage;
        Debug.Log(playerName + "의 현재 체력 : " +  currentHp);
    }
    public float PlayerHeal()//플레이어의 체력회복량
    {
        return (playerAttackDamage / 10f);
    }
    public void Heal(float _healing)//플레이어는 몬스터를 공격하고나서 자신의 공격력의 10%만큼 체력회복
    {
        float healedHp = currentHp + _healing;

        if (healedHp > playerMaxHp)
        {
            currentHp = playerMaxHp;
            Debug.Log(playerName + "의 체력 : " + currentHp);
        }
        else
        {
            currentHp = healedHp;
            Debug.Log(playerName + "의 힐 후의 체력 : " + healedHp);
        }
    }
}

class Player1 : Player //플레이어1
{
   public Player1()
    {
        playerName = "zI존용사";
        playerJob = "전사";
        playerSkill = "Smash";
        playerAttackDamage = 20f;
        playerMaxHp = 250f;
        currentHp = playerMaxHp;
    }
}

class Player2 : Player //플레이어2
{
    public Player2()
    {
        playerName = "MAGICKING";
        playerJob = "마법사";
        playerSkill = "Meteor";
        playerAttackDamage = 40f;
        playerMaxHp = 180f;
        currentHp= playerMaxHp;
    }
}


class Enemy //적
{
    private string enemyName = "보스";
    private float enemyAttackDamage = 13f;
    protected float currentHp = 400f;
    private string enemySkill = "물어뜯기";

    public void EnemyStat()//적 정보
    {
        Debug.Log("적 정보" + "\n" + "이름 : " + enemyName + ", 적 공격력 : " + enemyAttackDamage + ", 적 체력 : " + currentHp);
    }
    public void EnemyCastSkill()//적 공격
    {
        Debug.Log("보스" + enemySkill + " 발동");
    }
    public float EnemyHp()//적 현재체력
    {
        return currentHp;
    }
    public float GetEnemyAttackDamage()//적의 공격력 저장
    {
        return enemyAttackDamage;
    }
    public void EnemeyCurrentHp(float _playerAttackDamage)//적이 플레이어로 부터 공격받고 난 후의 체력
    {
        currentHp -= _playerAttackDamage;
        if (currentHp < 0)
        {
            currentHp = 0;
        }
        Debug.Log(enemyName+"의 체력 : "+currentHp);
    }
}