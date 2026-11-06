using UnityEngine;
namespace SimpleGame_20260810
{
    public class SpeedItem : Item
    {
        private float speedAmount = 5f;

        public override void Use(Player _player)
        {
            _player.IncreaseSpeed(speedAmount);
            gameObject.SetActive(false);
        }
    }
}