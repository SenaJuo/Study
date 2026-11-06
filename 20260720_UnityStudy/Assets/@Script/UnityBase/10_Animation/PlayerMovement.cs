using UnityEngine;
namespace MyAnimation 
{  
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody rb = null;
        [SerializeField] private float moveSpeed = 0f;
        [SerializeField] private float accelerationSpeed = 0f;
        [SerializeField] private float maxRunSpeed = 0f;
        [SerializeField] private float walkSpeed = 0f;

        private float currentMoveSpeed = 0f;


        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 inputDirection = new Vector3(horizontal, 0f, vertical);
            Vector3 normalizedDirection = inputDirection.normalized;

            rb.linearVelocity = normalizedDirection * moveSpeed;

            if (normalizedDirection.magnitude > 0.1f)
            {
                UnityEngine.Quaternion targetRotation = UnityEngine.Quaternion.LookRotation(normalizedDirection);
                rb.rotation = UnityEngine.Quaternion.Slerp(rb.rotation, targetRotation, 10f);
            }
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //달리기 하는 상황
                moveSpeed += accelerationSpeed * Time.deltaTime;
                //가속이 되다가, maxRunSpeed에 도달하면
                //moveSpeed는 가속이 되면 안되고, maxRunSpeed가 고정되게 들어가야함
                if (moveSpeed > maxRunSpeed)
                {
                    moveSpeed = maxRunSpeed;
                }
            }
            else
            {
                moveSpeed -= accelerationSpeed * Time.deltaTime;
                if (moveSpeed < walkSpeed)
                {
                    moveSpeed = walkSpeed;
                }
            }
            Vector3 velocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
            currentMoveSpeed = velocity.magnitude;
            
        }

        public float GetCurrentMoveSpeed()
        {
            return currentMoveSpeed;
        }
    }
}