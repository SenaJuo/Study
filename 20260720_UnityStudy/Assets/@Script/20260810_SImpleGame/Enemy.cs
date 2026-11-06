using UnityEngine;
namespace SimpleGame_20260810 {
    public class Enemy : MonoBehaviour
    {
        //hp, damage
        private float hp = 0f;
        private float damage = 0f;

        private void Awake()
        {
            hp = 100f;
            damage = 7f;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                Player player = collision.gameObject.GetComponent<Player>();
                player.GetDamage(damage);
            }
        }


        //인자로 받은 데미지 만큼, 자신의 hp를 깎는 기능
        public void GetDamage(float _damage)
        {
            if(hp > 0)
            {
                hp -= _damage;
                Debug.Log("Enemy의 체력 : " + hp); 
                if (hp <= 0)
                {   //본인 오브젝트 비활성화
                    Debug.Log("Enemy사망"); 
                    gameObject.SetActive(false);
                }
            }
           
            //hp를 계속 빼주니 체력이 음수가 되어버리는 문제가 발생

            
        }
    }
}