using UnityEngine;
namespace MyAnimation
{

    public class PlayerAnimation : MonoBehaviour
    {
        private Animator animator = null;
        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }
        public void GetEvent()
        {
            Debug.Log("SHOOT!");
        }

        public void GetSetFloat(string _name, float _float)
        {
            animator.SetFloat(_name, _float);
        }

        public void GetSetTrigger(string _event)
        {
            animator.SetTrigger(_event);
        }
    }
}