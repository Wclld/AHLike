using UnityEngine;
using AHLike.Data.Weapon;

namespace AHLike.Weapon
{
    public class Missile : MonoBehaviour 
    {
        private Rigidbody _rigidbody;

        
        public void Init(MissileData data, Vector3 target)
        {
            _rigidbody = GetComponent<Rigidbody>();
            transform.LookAt(target);
            _rigidbody.velocity = Vector3.forward * data.FlightSpeed;
        }

        private void OnCollisionEnter(Collision other) 
        {
            Destroy(gameObject);    
        }
    }
}
