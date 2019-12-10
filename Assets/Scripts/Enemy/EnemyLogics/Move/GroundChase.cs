using UnityEngine;
using UnityEngine.AI;

namespace AHLike.Enemy.EnemyLogics
{
    public class GroundChase : Chase
    {
        private NavMeshAgent _agent;
        
        
        public override void Move()
        {
            if(_agent == null)
            {
                _agent = Transform.GetComponent<NavMeshAgent>();
                if(_agent == null)
                {
                    return;
                }
            }
            _agent.SetDestination(_target.position);
        }

        public override void SetLayer()
        {
            Transform.gameObject.layer = LayerMask.NameToLayer("GroundEnemy");
        }
    }
}
