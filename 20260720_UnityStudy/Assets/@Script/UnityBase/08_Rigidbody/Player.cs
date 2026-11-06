using UnityEngine;
namespace MyRigidbody 
{
    public class Player : MonoBehaviour
    {
        /*
         * 물리처리를 기반으로 Player를 움직일거임
         * Transform 기반으로 움직여도 괜찮지만, Transform 기반으로 움직이면,
         * 매 프레임 조금씩 좌표만 수정하는 개념이라서, 이동속도가 빨라지거나 했을때
         * 벽을 뚫어버리는 문제가 발생함. 그래서 보통 Player를 구현할때는
         * 물리처리를 기반으로한 구현방식을 사용함
         * Transform 기반으로 움직임을 구현할때도 있는데,
         * Rigidbody의 연산이 가볍지 않기 때문에
         * 굳이 물리처리가 필요없는 이동하는 장애물 같은것들은 Transform 기반으로 구현하면 됨
         */
        private Rigidbody rb = null;
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float jumpPower = 5f;
        [SerializeField] private bool isGround = true;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            //이동하는 함수
            Move();
           
        }
         private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
             if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            Debug.DrawRay(transform.position, -transform.up * 1.1f, Color.red);

            GetItem();
            if (!Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1.1f))
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    Debug.Log("K버튼 눌러짐");
                    rb.isKinematic = !rb.isKinematic;
                    
                }
            }
        }

        private void GetItem()
        {
            //일단, 플레이어가 바라보는 앞쪽방향으로 RayCast를 쏠거임(3f)
            //RayCast에 맞은 물체를 가져와서, 그 물체안에 있는 Item Component를 가져와볼거임
            //만역에, Item이 비어있지 않았을때, 만약에 왼쪽 마우스 버튼을 눌렀을때
            //item.Use()를 호출할거임
            Debug.DrawRay(transform.position, transform.forward * 3f, Color.violet);
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 3f))
            {
                Item item = hit.collider.gameObject.GetComponent<Item>(); //hit는 collider를 가져옴
                if(item != null)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        item.Use();
                    }
                }
            }
        }

        private void Move()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = transform.forward*vertical + transform.right*horizontal;
            Vector3 normalizedDirection = direction.normalized;
            Vector3 newVelocity = new Vector3(normalizedDirection.x * moveSpeed, rb.linearVelocity.y, normalizedDirection.z * moveSpeed);

            rb.linearVelocity = newVelocity;
        }

        private void Jump()
        {
            //Rigidbody의 y속도를 건들면 됨
            //y쪽으로 일정만큼 힘을 주면 됨
            //AddForce라는 함수를 사용하면 됨

            //Physics.Raycast
            //Physics.Raycst(기준 위치, 목표점까지, 부딪힌 물체, 레이저의 거리)
            //반환값은 bool값 (Raycast랑 특정 물체랑 부딪혔는지 안부딪혔는지 판별)
            if(Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 1.1f))
            {
                Debug.Log("Raycast중임");
                rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
                rb.AddForce(new Vector3(0f, 1f, 0f) * jumpPower, ForceMode.Impulse);
            }
        
            //Debug.DrawRay(내 위치, 방향벡터 * 길이, 색상)
            

            //점프를 하기는 해야하는데
            //Space를 누를때마다 계속 점프가 되는게 문제
            //해결책 >> 플레이어가 땅에 붙어있을때만 Space를 눌렀을때, Jump가 되어야 할듯
        }

        private void OnCollisionEnter(Collision collision)
        {
            Ground ground = collision.gameObject.GetComponent<Ground>();
            if(ground != null)
            {
                isGround = true;
            }   
        }
        private void OnCollisionExit(Collision collision)
        {
            Ground ground = collision.gameObject.GetComponent<Ground>();
            if (ground != null)
            {
                isGround = false;
            }
        }
    }
}