using System;
using UnityEngine;

namespace AHLike.Movement
{
    internal abstract class MovementInput 
    {
        internal event Action OnInputBegin;
        internal event Action OnInputEnded;

        protected Vector3 _movementDirection;

        private bool _isMoving = false;


        protected abstract Vector3 DetectMovementDirection();


        internal Vector3 GetMovement()
        {
            _movementDirection = DetectMovementDirection();
            
            if(_movementDirection == Vector3.zero)
            {
                if(_isMoving)
                {
                    OnInputEnded?.Invoke();
                    _isMoving = false;
                }
            }
            else
            {
                if(!_isMoving)
                {
                    OnInputBegin?.Invoke();
                    _isMoving = true;
                }
            }
            return _movementDirection;
        }
    }
}
