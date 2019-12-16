using UnityEngine;
using AHLike.Movement;
using System;

namespace AHLike.Player
{
    [RequireComponent(typeof(Rigidbody))]
    internal class PlayerController : MonoBehaviour 
    {
        [SerializeField] float _moveSpeed = 300;
        private Rigidbody _rigidbody;
        private MovementInput _input;
        private Vector3 _movement;
        private Quaternion _direction;

        internal void Init(MovementInput input)
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            _input = input;
        }

        private void Update() 
        {
            _movement = _input.GetMovement();
            _movement *= _moveSpeed * Time.deltaTime;
            _direction.eulerAngles = _movement.normalized; 
        }    

        private void LateUpdate() 
        {
            _rigidbody.velocity = _movement;
            if(_movement != Vector3.zero)
            {
                _rigidbody.transform.rotation = Quaternion.LookRotation(_movement,Vector3.up);
            }    
        }

        private void SetSpeed(float speed)
        {
            _moveSpeed = speed;
        }
    }
}
