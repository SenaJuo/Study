using UnityEngine;
namespace MyRigidbody 
{ 
    public class Item : MonoBehaviour
    {
        public void Use()
        {
            Debug.Log("아이템 사용됨");
            gameObject.SetActive(false);
        }
    }
}