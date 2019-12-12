using UnityEngine;
using AHLike.Data.Weapon;

namespace AHLike.Weapon
{
    public class Missile : MonoBehaviour 
    {
        Rigidbody _rb;
        public void Init(MissileData data, Vector3 target)
        {
            _rb = GetComponent<Rigidbody>();
            transform.LookAt(target);
            _rb.velocity = Vector3.forward * data.FlightSpeed;
        }

        private void OnCollisionEnter(Collision other) 
        {
            Destroy(gameObject);    
        }
    }
}
