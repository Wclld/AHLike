using UnityEngine;
using AHLike.Data.Weapon;
using AHLike.Target;

namespace AHLike.Weapon
{
    public class Missile : MonoBehaviour 
    {
        private Rigidbody _rigidbody;
        private MissileData _data;
        
        public void Init(MissileData data, Vector3 target)
        {
            _rigidbody = GetComponent<Rigidbody>();
            transform.LookAt(target);
            var direction = target - transform.position;
            _rigidbody.velocity = direction.normalized * data.FlightSpeed;
            _data = data;
        }

        private void OnCollisionEnter(Collision other) 
        {
            var damagableObject = other.gameObject.GetComponent<IDamagable>(); 
            if(damagableObject != null)
            {
                damagableObject.DealDamage(_data.Damage);
            }
            Destroy(gameObject);    
        }
    }
}
