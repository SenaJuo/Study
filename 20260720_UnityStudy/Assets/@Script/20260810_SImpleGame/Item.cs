using UnityEngine;
namespace SimpleGame_20260810
{
    public abstract class Item : MonoBehaviour
    {
        /*HealItem, SpeedItem, PowerItem의 추상화된 클래스임
         * 추상화된 클래스임
         * 
         * Item들을 지금 보니까
         * 뭔가를 쓴다? 정도의 행동을 하는거 같음
         * GrantSpeed, GrantPower, HealPlayer를
         * Use()라는 함수로 추상화 가능할 듯
         * 
         * 아이템들은 공통적으로 Rotate()라는 기능을 수행함
         * 이것도 Item에 한번만 정의하면 좋을듯
         * 
         * 리팩터링
         * Refactoring
         * 기능을 만들어놓고, 기능의 변화 없어, 코드를 유지보수하기 좋게 만드는 기법
         */
        protected float rotationSpeed = 25f;
        private TransformUtil util = null;
        private ItemSpawner itemSpawner = null;
        
        public abstract void Use(Player _player);
        protected virtual void Awake()
        {
            util = new TransformUtil();
        }

        public void SetItemSpawner(ItemSpawner _itemSpawner)
        {
            itemSpawner = _itemSpawner;
        }
        protected virtual void Update()
        {
            Rotate();
        }

        protected virtual void Rotate()
        {
            util.Rotate(transform, new Vector3(0f, 1f, 0f), rotationSpeed);
        }

        private void OnDisable()
        {
            itemSpawner.RemoveItemFromList(this);
            itemSpawner.CreateRandomItem(transform);
        }
    }
}
