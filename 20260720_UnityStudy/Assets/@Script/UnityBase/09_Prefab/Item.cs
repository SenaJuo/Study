using UnityEngine;
namespace MyPrefab 
{ 
    public class Item : MonoBehaviour
    {
        public void SetName(string _name)
        {
            transform.name = _name;
        }
        public void PrintName()
        {
            Debug.Log(transform.name);
        }
    }
}