using System.Runtime.CompilerServices;
using UnityEngine;

/*
  Player
  체력과 경험치를 가지고 있음
  무기를 가지고 있고, 무기를 장착할 수도 있음
  무기를 장착하고 있을때만, 적을 공격할 수 있음
  무기를 가지고 적을 때리다가, 적이 죽으면 플레이어는 일정량의 경험치를 얻음
  플레이어의 체력이 0이 되면, 플레이어도 사망
  
  
  
   Player 정보 : 변수
   1.hp
   2.exp
   3.무기
   
   기능 : 함수
   1. 무기를 장착하는 기능
   2. 적을 공격하는 기능
   3. 경험치를 얻는 기능
   4. 플레이어가 죽었는지 살았는지 알 수 있는 기능
   5. 플레이어가 데미지를 받는 기능
   
   Enemy
   체력, 공격, 드랍하는 경험치의 양을 가지고 있음
   플레이어를 공격해서, 플레이어가 데미지를 받을수있게 해아함
   피해를 입다가 체력이 0이 되면 사망
   만약에 Enemy가 죽으면, 자신이 드랍하는 경험치를 Plyer에게 부여 해야함
  
   Enemy 정보 :
   1. hp(체력)에 대한 정보
   2. Enemy고유의 damage
   3. Enemy가 죽었을 때, Player에게 주는 경험치량(dropExp)
  
   기능 : 
   1. Player를 공격하는 기능
   2. 데미지를 입는 기능
   3. dropExp를 가져오는 기능
   4. 자기가 살아있는지, 죽었는지 알려주는 기능
  
  
   Weapon
   무기의 공격력이 얼마인지에 대한 정보가 있어야 함
   플레이어가 원할 떄, 무기의 데메지를 가져올 수 있어야 함
   무기는 Staff, Bow, Sword 3가지의 종류가 있음
   Staff 공격력 : 1, Bow 공격력 : 20, Sword 공격력 : 50
   
   Staff
   데미지를 반환하는 기능
   데미지 : 1
   
   Bow
   데미지를 반환하는 기능
   데미지 : 20
   
   Sword
   데미지를 반환하는 기능
   데미지 : 50
   
 */
namespace MyComposition
{
    public class Composition : MonoBehaviour
    {
        private void Start()
        {
            Player player = new Player();
            Enemy enemy = new Enemy();
            Sword sword = new Sword();
            Bow bow = new Bow();
            Staff staff = new Staff();

            //Player에게 Weapom을 하나 달아줘야 함


            /*Solid 원칙 중에서
             * SRP
             * Single Responsibilty Principle
             * 단일 책임 원칙
             * 각자의 클래스는 각자의 클래스에 대한 책임만 져야함
             * ex) Player는 Player에 해당하는 기능 또는 정보만 가지고 있어야 함
             * Player가 Enemy에 대한 정보를 가지고 있으면 안됨
             * 
             * 
             * OCP
             * Open Closed Principle
             * 개방 폐쇄 원칙
             * 기능의 확장에는 열려있고
             * 기능의 변경에는 닫혀있어야 한다는 원칙
             * 
             * LSP
             * Liskov Substituation Principle
             * 리스코프 치환의 원칙
             * 자식 클래스가 부모 클래스를 완벽하게 대체할 수 있어야 함
             * Sword, Staff, Bow는 완벽하게 Weapon에 해당함
             * Apple클래스가 Weapon을 상속받으면 이상해짐
             * 
             * DIP
             * Dependency Inversion Principle
             * 의존성 역전의 원칙
             * 상속을 통해서 의존성을 역전시켜야 관리가 편하다
             * Player는 Weapon에 의존하고, Staff, Bow, Sword는 Weapon에 의존함
*/
            player.EquipWeapon(staff);
            player.Attack(enemy);
            enemy.Attack(player);

            player.EquipWeapon(sword);
            player.Attack(enemy);
            enemy.Attack(player);
            player.Attack(enemy);

        }
    }
    public class Player
    {
        private float hp = 0f;
        private float exp = 0f;



        //무기의 종류마다, 변수가 생겨야 하고, Attack을 할 때, 각 무기의 종류 만큼의 if문이 생겨야 함
        //다형성
        //부모의 형태로 자식을 생성할 수 있는 기능
        private Weapon weapon;

        public Player()
        {
            hp = 100f;
            exp = 0f;
        }


        public void EquipWeapon(Weapon _weapon)
        {
            weapon = _weapon;
            Debug.Log(weapon.WeaponName()+" 습득");
            Debug.Log("플레이어가 무기를 장착 : " + weapon.WeaponName());
        }

        public void Attack(Enemy _enemy)
        {
            //공격을 할 때, 무기가 없으면, 공격하면 안됨
            //null : 객체가 아무것도 없을때 사용하는 자료형
            if (weapon == null)
            {
                Debug.Log("무기가 장착 되어있지 않습니다.");
                return;
            }
            //외부로부터 내가 때릴 Enemy의 정보를 받을거임
            //받은 Enemy의 정보를 보고, 만약에 Enemy가 살아있으면, 공격을 진행함
            if (!_enemy.IsDead())
            {
                _enemy.GetDamage(weapon.Attack());  
            }
            //공격을 했는데, Enemy가 죽었으면?
            //Enemy의 Exp를 가져와서, Player의 exp에 더해주면 됨
            if (_enemy.IsDead())
            {
                //exp += _enemy.GetDropExp();
                GetExp(_enemy.GetDropExp());
                Debug.Log("플레이어의 경험치 " + exp);
            }
        }

        private void GetExp(float _exp)
        {
            exp += _exp;
        }

        public bool IsDead()
        {
            bool result = false;
            result = hp <= 0;
            return result;
        }

        public void GetDamage(float _damage)
        {
            hp -= _damage;
            Debug.Log("Player가 공격받음, 현재 HP : " + hp);
        }
    }

    public class Enemy
    {
        private float hp = 0f;
        private float damage = 0f;
        private float dropExp = 0f;

        public Enemy()
        {
            hp = 100f;
            damage = 20f;
            dropExp = 50f;
        }
        public void Attack(Player _player)
        {
            //외부로 부터 공격해야하는 Player를 받고
            //만약 그 Player가 죽지 않았다면, 공격을 할거고
            //Player를 공격하다가 Player가 죽으면
            //게임종료! 라는 문구를 출력 해보겠음
            if (!_player.IsDead())
            {
                _player.GetDamage(damage);
            }
            if(_player.IsDead())
            {
                Debug.Log("게임 종료");
            }
        }

        public void GetDamage(float _damage)
        {
            hp -= _damage;
            if(hp < 0)
            {
                hp = 0;
            }
            Debug.Log("Enemy가 공격을 받음 : " + _damage + " 현재 HP : " + hp);
        }

        public float GetDropExp()
        {
            return dropExp;
        }

        public bool IsDead()
        {
            return hp <= 0;

        }
    }

    /*
     * Sword, Staff, Bow를 만들다 보니
     * 셋 다 비슷한 기능을 하는것 같음
     * damage라는 변수가 있고, Damage를 반환하는 기능이 있음
     * 그래서 흐린눈을 떠서 Sword, Staff, Bow를 포함하는 하나의 개념으로 만듦(추상화)
     * 그 클래스를 Weapon 이라고 명명함
     */

    public class Weapon
    {
        protected float damage = 0f;
        protected string weaponName = "";
        //지금은 데미자만 반환하는 기능을 함

        //데미지만 반환하는게 아니라
        //Sword :  벤다!
        //Bow : 활을 쏜다!
        //Staff : 마법을 쓴다!
        //라는 문구를 출력한 가음에 damage를 반환하고 싶음

        //override 기능
        //부모의 함수를 자식이 확장할 수 있는 기능
        //부모의 함수를 자식이 확장하려면, 부모의 함수가 virtual 함수로 선언되어 있어야 함
        public string WeaponName()
        {
            return weaponName;
        }
        public virtual float Attack()
        {
            return damage;
        }
    }

    public class Staff : Weapon
    {
        public Staff()
        {
            weaponName = "지팡이";
            damage = 1f;
        }
        public override float Attack()
        {
            Debug.Log("마법을 쓴다!");
            //부모에 있는 GetDamage함수를 써서 반환함
            return base.Attack();
        }
    }

    public class Bow : Weapon
    {
        public Bow()
        {
            weaponName = "활";
            damage = 20f;
        }
        public override float Attack()
        {
            Debug.Log("화살을 쏜다!");
            //부모에 있는 GetDamage함수를 써서 반환함
            return base.Attack();
        }
    }
    public class Sword : Weapon
    {
        public Sword()
        {
           weaponName = "검";
           damage = 50f;
        }
        public override float Attack()
        {
                Debug.Log("검으로 벤다!");
                //부모에 있는 GetDamage함수를 써서 반환함
                return base.Attack();
        }
    }
 }