using System;
using UnityEngine;

namespace AHLike.Movement
{
    [Serializable]
    public class MovementController
    {
        [SerializeField] Rigidbody _rigidbody;
        [SerializeField] float _moveSpeed = 300;
        private MovementInput _input;
        private Vector3 _movement;
        private Quaternion _direction;

        public MovementController()
        {
            #if UNITY_EDITOR
            _input = new KeyboarInput();        
#else 
            _input = new JoystickInput();
#endif    

            SubscribeOnInputBegin(()=> Debug.Log("On input Begin"));
            SubscribeOnInputEnded(()=> Debug.Log("On input Ended"));            
        }

        public void Update()
        {
            _movement = _input.GetMovement();
            _movement *= _moveSpeed * Time.deltaTime;
            _direction.eulerAngles = _movement.normalized;
        }

        public void LateUpdate() 
        {
            _rigidbody.velocity = _movement;
            if(_movement != Vector3.zero)
            {
                _rigidbody.transform.rotation = Quaternion.LookRotation(_movement,Vector3.up);
            }
        }

        public void SubscribeOnInputBegin(Action callback)
        {
            _input.OnInputBegin += callback;
        }

        public void SubscribeOnInputEnded(Action callback)
        {
            _input.OnInputEnded += callback;
        }
    }
}
