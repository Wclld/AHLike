using AHLike.Enemy.EnemyLogics;
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
        [SerializeField] GameObject _attackLogic;
        [SerializeField] GameObject _moveLogic;
        public IAttack AttackLogic => GetInterface<IAttack>(_attackLogic);
        public IMove MoveLogic => GetInterface<IMove>(_moveLogic);

        private T GetInterface<T>(GameObject interfaceObject) where T: class
        {
            T result;
            
            if (interfaceObject != null) 
            {
                result = interfaceObject.GetComponentInChildren<T> ();
            } 
            else 
            {
                result = interfaceObject as T;
            }
            return result;
        }
    }
}