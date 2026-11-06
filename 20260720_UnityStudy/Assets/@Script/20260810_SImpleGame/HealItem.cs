using UnityEngine;
namespace SimpleGame_20260810 { 
    public class HealItem : Item
    {
        private float healAmount = 0f;
        protected override void Awake()
        {
            base.Awake();
            healAmount = 5f;
        }
        public override void Use(Player _player)
        {
            if (_player.GetHp() < _player.IsMaxHp()) 
            { 
            _player.GainHp(healAmount);
            gameObject.SetActive(false);
            }
        }


        //public override void Use(Player _player)
        //{
        //    if (!_player.IsMaxHp1())
        //    {
        //        _player.GainHp(healAmount);
        //        gameObject.SetActive(false);
        //    }
        //}
    }
}