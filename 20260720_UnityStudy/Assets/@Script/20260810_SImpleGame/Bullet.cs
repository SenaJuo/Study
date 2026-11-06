using MyCollision;
using Unity.Mathematics;
using UnityEngine;
namespace SimpleGame_20260810
{ 
    public class Bullet : MonoBehaviour
    {
        private Rigidbody rb = null;
        [SerializeField]private float moveSpeed = 0f;

        [SerializeField] private GameObject effectPrefab = null;

        private void Awake()
        {
            moveSpeed = 10f;
            rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            Destroy(gameObject, 3f);
        }
        private void FixedUpdate()
        {
            rb.linearVelocity = transform.forward * moveSpeed;
        }

        private void OnCollisionEnter(Collision _collision)
        {
            //Enemy랑 부딪히면 Enemy한테 데미지를 주고 총알 본인은 사라질거임
            Enemy enemy = _collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetDamage(50f);
            }

            //가장 먼저 부딪힌 지점을 가져오는 방법
            //collision.contacts[0].point << Vector3로 가져올수 있음
            Vector3 contactPosition = _collision.contacts[0].point;
            Instantiate(effectPrefab, contactPosition, UnityEngine.Quaternion.identity);

            gameObject.SetActive(false);
        }
      
    }
}
