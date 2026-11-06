using UnityEngine;
namespace MyCollision
{ 
    public class God : MonoBehaviour, IDamageable
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void OnDamaged()
        {
            Debug.Log("God이 데미지를 받음");
        }
    }
}