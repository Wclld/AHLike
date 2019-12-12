using System;
using UnityEngine;

namespace AHLike.Movement
{
    public abstract class MovementInput 
    {
        public event Action OnInputBegin;
        public event Action OnInputEnded;

        protected Vector3 _movementDirection;

        private bool _isMoving = false;


        protected abstract Vector3 DetectMovementDirection();
        public void ClearEvents()
        {
            OnInputBegin = null;
            OnInputEnded = null;
        }


        public Vector3 GetMovement()
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
