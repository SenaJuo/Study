using System;
using Unity.VisualScripting;
using UnityEngine;
namespace SimpleGame_20260810 { 
    public class Player : MonoBehaviour
    {
        //hp, damage, speed
        private float hp = 0f;
        private float damage = 0f;
        private float currentSpeed = 0f;
        private float maxHp = 100f;

        private float originalSpeed = 0f;
        private float accelerationTime = 0f;
        private bool isAcceleration = false;
        private float maxAccelerationTime = 3f;

        private ShootPos shootPos = null;

        [SerializeField] private GameObject bulletPrefab = null;

        private float currentPitch = 0f;
        private Transform cameraTransform = null;

        [SerializeField] private float sensitivity = 2f;
        private void Awake()
        {
            hp = 100f;
            damage = 20f;
            currentSpeed = 5f;
            originalSpeed = currentSpeed;
            shootPos = GetComponentInChildren<ShootPos>();
            cameraTransform = GetComponentInChildren<Camera>().GetComponent<Transform>();

        }

        private void Update()
        {
            MoveWithAxis();
            CheckAccelerationTime();
            Fire();
            Rotate();
        }

        private void Fire()
        {
            //마우스 왼쪽 버튼 뉼렀을때, shootPos위치에 bullet오브젝트가 생성
            if (Input.GetMouseButtonDown                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           (0))
            {
                Instantiate(bulletPrefab, shootPos.transform.position, shootPos.transform.rotation);
            }
        }
        private void CheckAccelerationTime()
        {
            //시간을 계속 누적함(60프레임 기준 매 프레임 0.02씩 더해짐)
            if(isAcceleration == true) 
            { 
                accelerationTime += Time.deltaTime;
                //Debug.Log("Update::accelerationTime" + accelerationTime);
                bool shouldStopAcceleration = accelerationTime >= maxAccelerationTime;
                if(shouldStopAcceleration)
                {
                    //속도를 원래대로 돌리면 됨
                   // Debug.Log("3초 지나서 if문 진입 ");
                    currentSpeed = originalSpeed;
                    isAcceleration = false;
                    accelerationTime = 0f;
                }
            }
        }
        private void MoveWithAxis()
        {
            float horizontal = Input.GetAxisRaw("Horizontal"); //수평
            float vertical = Input.GetAxisRaw("Vertical"); //수직

            Vector3 direction = new Vector3(horizontal, 0f, vertical);
            Vector3 normalizedDirection = direction.normalized;
            Vector3 moveDirection = transform.TransformDirection(normalizedDirection);
            transform.position += moveDirection * Time.deltaTime * currentSpeed;
        }

        private void OnCollisionEnter(Collision collision)
        {
            //충돌 구현
            //Enemy를 때려야 함
            //Enemy를 구분하는 방법 : Tag를 활용
            if(collision.gameObject.tag == "Enemy")
            {
                //여기서 Enemy한테 데미지
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                if(enemy != null) { 
                enemy.GetDamage(damage);
                }
            }
        }

        /*
         * 클래스로 추상화를 해야 할 때는 is-a 관계 (내 정체성)
         * 인터페이스로 추상화를 해야 할 때는 has-a 관계 (내 확장기능)
         */
        private void OnTriggerEnter(Collider other)
        {
            //HealItem healitem = other.gameObject.GetComponent<HealItem>();
            //if (healitem != null) {
            //    /*
            //     * HealPlayer의 인자로 Player를 넣어줘야함
            //     * Heal을 해야하는 주체는 나 자신임
            //     * 나 자신의 객체를 넣을때 this를 사용함
            //     */
            //    if(hp<100f)healitem.HealPlayer(this);
            //}

            //PowerItem poweritem = other.gameObject.GetComponent<PowerItem>();
            //if(poweritem != null)
            //{
            //    poweritem.GrantDamage(this);
            //}

            //SpeedItem speeditem = other.gameObject.GetComponent<SpeedItem>();
            //if(speeditem != null)
            //    {
            //    speeditem.GrantSpeed(this);
            //    }
            Item item = other.gameObject.GetComponent<Item>();
                item?.Use(this);           
        }

        public void GetDamage(float _damage)
        {
            hp -= _damage;
            Debug.Log("Player의 HP : " + hp );
            if (hp <= 0)
            {
                Debug.Log("Player 사망");
                gameObject.SetActive(false);
            }
        }
        public float IsMaxHp()
        {
            return maxHp;
        }
        public float GetHp()
        {
            return hp;
        }
        //public bool IsMaxHp1()
        //{
        //    return hp >= maxHp;
        //}
        /*
         * 1.Player의 체력이 100이상으로 커지는게 문제임
         * 2. 아이템이 안사라짐(아이템 계속 사용가능)
         * 기획은 - 플레이어의 체력이 100이하일때만 아이템을 사용가능,
         * 체력이 100보다 크면, 아이템을 사용할 수 없음 (안사라짐)
         */
        public void GainHp(float _amount)
        {
            //힐이 된 hp를 미리 계산해보고
            //그 hp가 100보다 커져버리면
            //hp를 maxHp로 고정시키는 로직이 필요할듯
            float tempHp = hp + _amount;
            if(tempHp >= maxHp)
            {
                tempHp = maxHp;
            }
            hp = tempHp;
            Debug.Log("Player HP : " + hp);
        }

        public void IncreaseDamage(float _damageAmount)
        {
            damage += _damageAmount;
            Debug.Log("Player의 Damage : " +  damage);
        }

        internal void IncreaseSpeed(float _speedAmount)
        {
            isAcceleration = true;
            currentSpeed += _speedAmount;
            //3초 센 다음에, 3초 지나면 current를 original로 바꿔주면 됨
            Debug.Log("Player의 Speed : " +  currentSpeed);
        }

        private void Rotate()
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            currentPitch -= mouseY * sensitivity;

            //지금 문제는 currentPtich를 계속 더하게 되면
            //카메라가 360도 회전되는게 문제임
            //그래서 currentPitch의 값을 범위로 제한해야 함
            //Mathf.Clamp(제한할 변수, 최소, 최대)
            currentPitch = Mathf.Clamp(currentPitch, -90f, 90f);

            //              ↓지금 본인이 가지고 있는 회전값
            cameraTransform.localEulerAngles = new Vector3(currentPitch, 0f, 0f);

            float playerRotation = mouseX * sensitivity;

            transform.Rotate(0f, playerRotation, 0f);
        }
    }
}
