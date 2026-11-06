using UnityEngine;
namespace SimpleGame_20260810 { 
    public class StartZine : MonoBehaviour
    {
        //StartZone은 IsTrigger가 체크되어있지만
        //얘는 Player가 들어와있는지를 체크해야해서 Player는 Collision처리가 되기 때문에
        //CollisionExit로 체크하면 될듯
        
        public void OnTriggerExit(Collider other)
        {
            Player player = other.gameObject.GetComponent<Player>();
            if(player != null)
            {
                Debug.Log("게임 시작!");
                gameObject.SetActive(false);
            }
        }

    }
}