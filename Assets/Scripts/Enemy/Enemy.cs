using System;
using System.Collections;
using AHLike.Data;
using AHLike.Enemy.EnemyLogics;
using UnityEngine;

namespace AHLike.Enemy
{
    public class Enemy : MonoBehaviour 
    {
        private string _name;
        private float _attackRate;
        private float _damage;
        private IAttack _attackLogic;
        private IMove _moveLogic;
        [SerializeField] bool _alive = true;

        public void SetFromInfo(EnemyInfo info)
        {
            _name = info.Name;
            _attackRate = info.AttackRate;
            _damage = info.Damage;
            //Instantiate()
            _attackLogic = info.AttackLogic;
            //_moveLogic = info.MoveLogic.;
            Debug.Log("transform", transform);
            _moveLogic.Transform = transform;
            _moveLogic.Speed = info.MoveSpeed;
            _moveLogic.SetLayer();
        }

        internal void Move()
        {
            StartCoroutine(MoveCoroutine());
        }

        private IEnumerator MoveCoroutine()
        {
            while(_alive)
            {
                Debug.Log("moving", gameObject);
                _moveLogic.Move();
                yield return null;
            }
        }

        public void SetTarget(Transform target)
        {
            _moveLogic.SetTarget(target);
        }
    }
}
