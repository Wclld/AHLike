using UnityEngine;

namespace AHLike.Enemy.EnemyLogics
{
    public class FlyChase : Chase 
    {
        public override void SetLayer()
        {
            Transform.gameObject.layer = LayerMask.NameToLayer("FlyingEnemy");
        }
        public override void Move()
        {
            var direction = (_target.position - Transform.position).normalized;
            var rb = Transform.GetComponent<Rigidbody>(); 
            rb.velocity = direction * Speed * 0.1f;
        }
    }
}