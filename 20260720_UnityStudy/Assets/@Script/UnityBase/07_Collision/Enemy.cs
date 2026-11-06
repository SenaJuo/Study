using UnityEngine;
namespace MyCollision 
{
    public class Enemy : MonoBehaviour, IDamageable
    {
        public void OnDamaged()
        {
            Debug.Log("Enemy가 데미지를 받음");
        }
    }
}