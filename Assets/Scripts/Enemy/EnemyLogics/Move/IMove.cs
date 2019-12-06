using UnityEngine;

namespace AHLike.Enemy.EnemyLogics
{
    public interface IMove 
    {
        float Speed { get; set; }
        Transform Transform { set; }
        void Move();    
        void SetTarget(Transform target);
        void SetLayer();
    }
}