using UnityEngine;
using AHLike.Movement;
using AHLike.Data;

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

        private void Start() 
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            #if UNITY_EDITOR
            _input = new KeyboarInput();        
#else 
            _input = new JoystickInput();
#endif    
            _input.OnInputBegin += ()=> Debug.Log("On input Begin");
            _input.OnInputEnded += ()=> Debug.Log("On input Ended");
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
