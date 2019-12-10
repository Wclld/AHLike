using UnityEngine;

namespace AHLike.Enemy.EnemyLogics
{
    public class AttackMoc : ScriptableObject,IAttack  
    {
        public void Attack()
        {
            Debug.Log("Attacking");
        }
    }
}