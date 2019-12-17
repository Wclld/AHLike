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
            var direction = target - transform.position;
            _rigidbody.velocity = direction.normalized * data.FlightSpeed;
        }

        private void OnCollisionEnter(Collision other) 
        {
            Destroy(gameObject);    
        }
    }
}
