using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
namespace SimpleGame_20260810 
{ 
    public class ItemSpawner : MonoBehaviour
    {
        /*ItemSpawner는 10개의 아이템이 존재해야 한다고 가정했을때,
         * 아이템이 사라짐을 감지하여 아이템이 없어진 위치에
         * 아이템을 새로 생성해주는 역할을 할 것임
         * 
         * 게임 시작했을때, 아이템들을 소환해주는 기능도 있어야 할듯
         */
        [SerializeField]private GameObject healItemPrefab = null;
        [SerializeField]private List<Transform>spawnPosition = null;

        [SerializeField] private List<Item> itemList = null;
        [SerializeField] private List<Item> spawnedItemList = null;

        //List에 있는 첫번째 Item을 가져오려면
        //itemList[0]
        //itemList[1]
        //itemList[2]

        private void Awake()
        {
            spawnedItemList = new List<Item>();
        }
        private void Start()
        {
            CreateRandomItem();
        }

      
        public void CreateRandomItem(Transform _transform)
        {
            if (spawnedItemList.Count < 10)
            {
                //새로운 아이템을 생성하면 됨

                int randomIndex = Random.Range(0, 3);
                Item item = itemList[randomIndex];
                GameObject itemObject = Instantiate(item.gameObject, _transform.position, _transform.rotation);

                //만들어진 게임오브젝트의 Item 컴포넌트를 가져와서 그거를 List에 넣어주면 됨
                Item itemComponent = itemObject.GetComponent<Item>();
                itemComponent.SetItemSpawner(this);
                spawnedItemList.Add(itemObject.GetComponent<Item>());
            }
        }
        
        //아이템을 랜덤하게 소환하는 기능
        private void CreateRandomItem()
        {
            //0,1,2 중에 숫자를 랜덤으로 뽑음 (뒤에 숫자는 포함이 안됨)
            
            
            for (int i = 0; i < spawnPosition.Count; ++i)
            {
                int randomIndex = Random.Range(0, 3);
                Item item = itemList[randomIndex];
                GameObject itemObject = Instantiate(item.gameObject, spawnPosition[i].position, spawnPosition[i].rotation);

                //만들어진 게임오브젝트의 Item 컴포넌트를 가져와서 그거를 List에 넣어주면 됨
                Item itemComponent = itemObject.GetComponent<Item>();
                itemComponent.SetItemSpawner(this);
                spawnedItemList.Add(itemComponent);
            }

        }

        public void RemoveItemFromList(Item _item)
        {
            //인자로 받은 아이템의 정보에 해당하는 녀석을 리스트에서 지워버릴거임
            spawnedItemList.Remove(_item);
        }
    }
}