using UnityEngine;
namespace SimpleGame_20260810
{
    public class TransformUtil
    {
        public void Rotate(Transform _transform,Vector3 _direction, float _speed)
        {
            _transform.Rotate(_direction * _speed * Time.deltaTime);
        }
    }
}
