using UnityEngine;
namespace MyCollision { 

    public class Boss : MonoBehaviour, IDamageable
    {
    public void OnDamaged() 
        {
            Debug.Log("보스가 데미지를 받음");
            //본인 게임 오브젝트를 비활성화 할거임
            //gameObject.SetActive(false);
            //gameObject.SetActive(true);

            //본인 게임 오브젝트를 파괴할거임
            //Destroy(gameObject);
        }

    }
}