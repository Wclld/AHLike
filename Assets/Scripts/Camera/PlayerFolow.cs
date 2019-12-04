using UnityEngine;

namespace AHLike.Camera
{
    internal class PlayerFolow : MonoBehaviour 
    {
        [SerializeField] Rigidbody _target;
        [SerializeField] Vector3 _camOffset = Vector3.zero;
        [SerializeField] float _smoothTime;
        private Vector3 _velocity;


        private void Start() 
        {
            transform.LookAt(_target.position, Vector3.up);
        }

        private void LateUpdate()
        {
            var newPos = _target.position + _camOffset;
            newPos.x = 0;
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref _velocity, _smoothTime,float.MaxValue,Time.deltaTime);
        }
    }    
}
