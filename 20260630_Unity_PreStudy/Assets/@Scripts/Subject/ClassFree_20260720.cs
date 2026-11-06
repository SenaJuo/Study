using UnityEngine;

public class ClassFree_20260720 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Enemy2 enemy2 = new Enemy2();
        Sword sword = new Sword();
        Magician magician = new Magician();
        Thief thief = new Thief();
        Goblin goblin = new Goblin();
        Mushroom mushroom = new Mushroom();


        Debug.Log("--------적 정보--------");
        goblin.EnemyStatus();//고블린 정보
        mushroom.EnemyStatus();//머쉬룸 정보
        Debug.Log("--------전사--------");
        sword.Status();//전사의 정보
        sword.Attack();//전사 공격
        enemy2.EnemyAttack();//적 공격(공통)
        sword.PlayerCurrentHp(goblin.GetEnemyAttackDamage()+mushroom.GetEnemyAttackDamage());//적에게 공격받고 난 후의 전사 hp 계산
        goblin.EnemyCurrentHp(sword.GetAttackDamage());//고블린의 hp
        mushroom.EnemyCurrentHp(sword.GetAttackDamage());//머쉬룸 hp
        Debug.Log("전사의 현재 체력 : " + sword.GetPlayerHp());
        Debug.Log("고블린의 현재 체력 : " + goblin.GetEnemyCurrentHp());
        Debug.Log("머쉬룸의 현재 체력 : " + mushroom.GetEnemyCurrentHp());


        Debug.Log("-------마법사-------");
        magician.Status();//마법사 정보
        magician.Attack();//마법사 공격
        enemy2.EnemyAttack();
        magician.PlayerCurrentHp(goblin.GetEnemyAttackDamage() + mushroom.GetEnemyAttackDamage());//적에게 공격받고 난 후의 마법사 hp 계산
        mushroom.EnemyCurrentHp(magician.GetAttackDamage());
        Debug.Log("마법사의 현재 체력 : " + magician.GetPlayerHp());
        Debug.Log("고블린의 현재 체력 : " + goblin.GetEnemyCurrentHp());
        Debug.Log("머쉬룸의 현재 체력 : " + mushroom.GetEnemyCurrentHp());


        Debug.Log("--------도적--------");
        thief.Status();//도적 정보
        thief.Attack();//도적 공격
        enemy2.EnemyAttack();
        thief.PlayerCurrentHp(goblin.GetEnemyAttackDamage() + mushroom.GetEnemyAttackDamage());//적에게 공격받고 난 후의 도적 hp 계산
        goblin.EnemyCurrentHp(thief.GetAttackDamage());
        mushroom.EnemyCurrentHp(thief.GetAttackDamage());
        Debug.Log("도적의 현재 체력 : " + thief.GetPlayerHp());
        Debug.Log("고블린의 현재 체력 : " + goblin.GetEnemyCurrentHp());
        Debug.Log("머쉬룸의 현재 체력 : " + mushroom.GetEnemyCurrentHp());
    }
}

class Player2//플레이어 공통
{
    protected float currentHp;
    protected string playerJob = " ";
    protected string playerName = " ";
    protected float attackDamage;

    public void Status()
    {
        Debug.Log("플레이어 직업 : " +playerJob+", 플레이어의 이름 : " + playerName +"\n"+ "현재 체력 : " + currentHp + ", 공격력 : " + attackDamage);
    }
    public virtual void Attack()
    {
        Debug.Log(playerJob + " 스킬 발동!");
    }
}

class Sword : Player2 //전사
{
    public Sword()
    {
        playerJob = "전사";
        playerName = "소드마스터";
        attackDamage = 10f;//전사의 공격데미지
        currentHp = 100f;//전사의 최초hp(현재hp)
    }
    public override void Attack()//전사 스킬 발동
    {
        base.Attack();
        Debug.Log("Smash");
    }
    public float GetAttackDamage()//데미지 저장
    {
        return attackDamage;
    }
    public void PlayerCurrentHp(float _enemyAttackDamage)
    {
        currentHp -= _enemyAttackDamage;
        if (currentHp < 0)//hp가 0밑이면
        {
            currentHp = 0;//0을 저장
        }
    }
    public float GetPlayerHp()//공격받은후의 hp
    {
        return currentHp;
    }
}

class Magician : Player2//마법사
{
    public Magician()
    {
        playerJob = "마법사";
        playerName = "매직마스터";
        attackDamage = 20f;//마법사의 공격데미지
        currentHp = 80;//마법사의 최초hp(현재hp)
    }
    public override void Attack()//마법사 스킬 발동
    {
        base.Attack();
        Debug.Log("Magic");
    }
    public float GetAttackDamage()//데미지 저장
    {
        return attackDamage;
    }

    public void PlayerCurrentHp(float _enemyAttackDamage)
    {
        currentHp -= _enemyAttackDamage;
        if (currentHp < 0)//hp가 0밑이면
        {
            currentHp = 0;//0을 저장
        }
    }
    public float GetPlayerHp()//공격받은후의 hp
    {
        return currentHp;
    }
}

class Thief : Player2 //도적
{
    public Thief()
    {
        playerJob = "도적";
        playerName = "도둑마스터";
        attackDamage = 30f;//도적의 공격데미지
        currentHp = 60;//도적의 최초hp(현재hp)
    }
    public override void Attack()//도적 스킬 발동
    {
        base.Attack();
        Debug.Log("Run");
    }
    public float GetAttackDamage()//데미지 저장
    {
        return attackDamage;
    }
    public void PlayerCurrentHp(float _enemyAttackDamage)
    {
        currentHp -= _enemyAttackDamage;
        if (currentHp < 0)//hp가 0밑이면
        {
            currentHp = 0;//0을 저장
        }
    }
    public float GetPlayerHp()//공격받은후의 hp
    {
        return currentHp;
    }
}
class Enemy2 //적 정보(공통)
{
    protected float enemyCurrnentHp;
    protected float enemyAttackDamage;
    protected string enemyType = " ";
    
    public void EnemyStatus() //적 정보
    {
        Debug.Log("적 타입 : " + enemyType + ", 적 공격력 : " + enemyAttackDamage + ", 적 현재 체력 : "+enemyCurrnentHp);
    }
    public void EnemyAttack()//적의 공통된 행동(attack)
    {
        Debug.Log("적이 Attack!");
    }
}

class Goblin : Enemy2 //고블린
{
    public Goblin() 
    {
        enemyType = "Goblin";
        enemyCurrnentHp = 80f;
        enemyAttackDamage = 20f;   
    }
    public float GetEnemyAttackDamage()
    {
        return enemyAttackDamage;
    }
    public void EnemyCurrentHp(float _playerAttackDamage)//goblin의 현재 체력에 플레이어의 데미지 만큼 차감
    {
        enemyCurrnentHp -= _playerAttackDamage;
        if (enemyCurrnentHp < 0) //hp가 0밑으로 가면
        {
            enemyCurrnentHp = 0; //현재 체력에 0을 저장
        }
    }
    public float GetEnemyCurrentHp()//공격받고 난 후의 hp
    {
        return enemyCurrnentHp;
    }
}

class Mushroom : Enemy2 //머쉬룸
{
    public Mushroom()
    {
        enemyType = "Mushroom";
        enemyCurrnentHp = 50f;
        enemyAttackDamage = 10f;
    }
    public float GetEnemyAttackDamage()
    {
        return enemyAttackDamage;
    }
    public void EnemyCurrentHp(float _playerAttackDamage) //mushroom의 현재 체력에 플레이어의 데미지 만큼 차감
    {
        enemyCurrnentHp -= _playerAttackDamage;
        if (enemyCurrnentHp < 0)//hp가 0밑이면
        {
            enemyCurrnentHp = 0;//0을 저장
        }
    }
    public float GetEnemyCurrentHp()//공격받고 난 후의 hp
    {
        return enemyCurrnentHp;    
    }
}