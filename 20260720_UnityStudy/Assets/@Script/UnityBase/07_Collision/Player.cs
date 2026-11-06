using UnityEngine;
namespace MyCollision
{
    public class Player : MonoBehaviour
    {
        /*
                 * 충돌(Collision)
                 * 충돌처리가 일어났을때, 호출되는 함수 OnCollisionEnter, OnTriggerEnter 등등
                 * 
                 * 충돌에는 2가지 상태가 있음
                 * Collision
                 * 물체 두개가 부딪혀서 서로 튕겨나가며 충돌을 하는 상태
                 * 
                 * Trigger
                 * 아이템 상자와 같이, 부딪힘을 감지만 하고,
                 * 물리적인 반응은 하지 말아야 할 때 사용
                 * 
                 * 
                 * 1.Collider가 필요함
                 * CapsuleCollider라는게 Player한테 달려 있음
                 * 
                 * 2.Rigidbody라는 컴포넌트가 필요함
                 * Collider만 달아서 돌렸을때는 안됐음. 충돌하는 개체가
                 * 물리처리를 해야하기 때문에 Rigidbody 컴포넌트를 달아주고 충돌체크를 해야함
                 * 충돌처리를 담당하는 주체만 Rigidvody를 가지고 있으면 됨
                 * 즉, Enemy는 굳이 Rigidbody가 없어도 됨
                 * (Rigidbody가 꽤 무거운 연산을 해서, 필요할 때만 쓰는게 좋음)
                 */


        private void OnCollisionEnter(Collision collision)
        {
            //Debug.Log("Player::충돌됨!");
            // Debug.Log("Player::충돌하는 물체의 이름 : " + collision.gameObject.name);

            /*
             * 충돌처리는 되는데
             * 누구랑만 충돌할건지 설정할 수 없음
             * Plane, Enemy 랑 충돌을 하고 있음
             * Enemy랑만 충돌을 하고 싶음
             * 
             * 1. 이름을 기준으로 Enemy를 구분하기
             */
            //if(collision.gameObject.name == "Enemy")
            //{
            //    Debug.Log("이름으로 구분된 Enemy랑 충돌!");
            //}

            //2. 객체의 Tag를 기준으로 구분하는 방법
            //if (collision.gameObject.CompareTag("Enemy"))
            //{
            //    Debug.Log("Tag로 구분된 Enemy랑 충돌!");
            //}

            //3. 충돌된 객체의 컴포넌트를 가져와서 구분하는 방식
            //충돌된 물체에 Enemy라는 컴포넌트가 null이 아닐때,
            //즉, 충돌된 물체에 Enemy라는 컴포넌트가 있을때
            //if (collision.gameObject.GetComponent<Enemy>() != null)
            //{
            //    Debug.Log("Enemy Component로 구분됨!");
            //}
            //물체는 물체인데, 데미지를 받을 수 있는 물체를 때리고 싶음
            //물체는 물체인데, 죽을 수 있는 물체를 때리고 싶음

            //4. 누구든 IDamageable을 가지고 있어서
            //데미지를 받을 수 있는 녀석을 골라서 때릴거임
            IDamageable damageableObject = collision.gameObject.GetComponent<IDamageable>();
            if(damageableObject != null)
            {
                damageableObject.OnDamaged();
            }
            
        }
        //Collision을 살펴봤는데,
        //부딪히면, 물리작용 때문에 튕겨나갔음
        //근데, 아이템을 먹는 상황에서
        //아이템을 먹을때마다 튕겨나가면 안되기 때문에
        //아이템과 플레이어가 충돌했다는 정보는 받으면서, 물리처리를 하고싶지 않을때
        //Trigger를 사용함
        //(BoxCollider의 isTrigger체크가 되어있어야 함)
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("트리거 됨 : " + other.gameObject.name);

            IDamageable damageableObject = other.gameObject.GetComponent<IDamageable>();
    
            //NullConditional 연산자
            //변수가 null이 아닐때만 뒤에오는 코드를 실행시킴
            damageableObject?.OnDamaged();
            //if (damageableObject != null)
            //{
            //    damageableObject.OnDamaged();
            //}

        }

        //Collision 중에, 서로 충돌이 끝났을때 호출
        //즉, 붙어있다가 떨어질때 호출
        private void OnCollisionExit(Collision collision)
        {
            
        }

        private void OnTriggerExit(Collider other)
        {
            
        }
        //두 물체가 충돌되는 동안 계속 호출됨
        //Update처럼 계속 호출되는 함수
        private void OnCollisionStay(Collision collision)
        {
            
        }

        private void OnTriggerStay(Collider other)
        {
            
        }
    }
    
}

//대충 유니티 오브젝트에 붙어있는 컴포넌트라고 생각해봅시다
//public class DamagableEnemy
//{

//}
//public class DamageablePlayer
//{

//}
//public class DieableEnemy
//{

//}
//public class DieablePlayer : Player, Dieable
//{

//}

//public class Enemy { }
//public class Player { }
//public class Damageable { }
//public class Dieable { }