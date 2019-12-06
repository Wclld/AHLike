using UnityEngine;

namespace AHLike.Enemy.EnemyLogics
{
    public abstract class Chase : MonoBehaviour, IMove
    {
        protected Transform _target;

        public float Speed { get; set; }
        public Transform Transform { protected get; set; }


        public abstract void Move();
        public abstract void SetLayer();

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        
    }
}