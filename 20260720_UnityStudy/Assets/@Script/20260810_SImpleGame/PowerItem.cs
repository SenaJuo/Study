using UnityEngine;
namespace SimpleGame_20260810
{
    
    
    public class PowerItem : Item
    {
        private float damageAmount = 0f;

        protected override void Awake()
        {
            base.Awake();
            damageAmount = 5f;
        }

        public override void Use(Player _player)
        {
            _player.IncreaseDamage(damageAmount);
            gameObject.SetActive(false);
        }
    }
}