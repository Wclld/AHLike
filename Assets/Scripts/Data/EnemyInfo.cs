using AHLike.Enemy.EnemyLogics;
using AHLike.Helpers;
using UnityEngine;

namespace AHLike.Data
{
    [CreateAssetMenu(fileName = "EnemyInfo", menuName = "AHLikeGame/EnemyInfo")]
    public class EnemyInfo : ScriptableObject 
    {
        public string Name;
        public GameObject Prefab;    
        public float MoveSpeed;
        public float AttackRate;
        public float Damage;
        [SerializeField] UnityEngine.Object _atackLogics;
        [SerializeField] UnityEngine.Object _moveLogics;
        public IAttack AttackLogic => ScriptableInterface.GetInterface<IAttack>(_atackLogics);
        public IMove MoveLogic => ScriptableInterface.GetInterface<IMove>(_moveLogics);
    }
}