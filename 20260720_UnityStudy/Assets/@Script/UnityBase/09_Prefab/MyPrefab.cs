using Unity.VisualScripting;
using UnityEngine;
namespace MyPrefab
{
    public class MyPrefab : MonoBehaviour
    {
        /*
         * Space를 눌렀을때, 원본 Item을 기준으로 월드에 Item 복사본을 생성하고 싶음
         */

        [SerializeField] private GameObject itemPrefab = null;
        private int count = 0;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                ++count;
                //원본을 기준으로 복사본을 생성
                //Instantiate
                //Instantiate(prefab, position, rotation)
                //반환값은, 월드에 만들어진 물체
                //즉, GameObject 형태를 반환함


                //Random.Range(최솟값, 최댓값)
                //최솟값 부터, 최댓값 까지 랜덤한 숫자를 뽑아줌
                //정수에서는 최소값은 inclusive, 최댓값은 exclusive  exclusive<<포함하지않음
                //실수에서는 최솟값~최댓값까지 랜덤한 숫자를 뽑아줌
                float randomX = Random.Range(-5f,5f);
                float randomY = Random.Range(-5f,5f);
                float randomZ = Random.Range(-5f,5f);
                GameObject itemObject = Instantiate(itemPrefab, new Vector3(randomX,randomY,randomZ),UnityEngine.Quaternion.identity, transform);

                MeshRenderer itemRenderer = itemObject.GetComponent<MeshRenderer>();
                if(itemRenderer != null)
                {
                    itemRenderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                }
                Item item = itemObject.GetComponent<Item>();
                if (item != null)
                {
                    item.SetName("커스텀아이템"+count);
                    item.PrintName();
                }
                 
            }
        }

    }
}