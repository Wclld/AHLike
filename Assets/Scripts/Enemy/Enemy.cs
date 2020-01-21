using System;
using System.Collections;
using UnityEngine;
using AHLike.Data;
using AHLike.Enemy.EnemyLogics;
using AHLike.Target;
using AHLike.UI.HealthBar;

namespace AHLike.Enemy
{
    public class Enemy : MonoBehaviour, IDamagable
    {
        private string _name;
        private float _attackRate;
        private float _damage;
        private IAttack _attackLogic;
        private IMove _moveLogic;
        private HealthPoints _hp;
        [SerializeField] bool _alive = true;
        public event Action<Enemy> OnDeath; 

        private void Update() 
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _hp.ChangeHP(-10);
            }    
        }

        public void SetStatsFromInfo(EnemyInfo info)
        {
            _name = info.Name;
            _attackRate = info.AttackRate;
            _damage = info.Damage;
            _attackLogic = info.AttackLogic;
            _moveLogic = info.MoveLogic;
            _moveLogic.Transform = transform;
            _moveLogic.Speed = info.MoveSpeed;
            _moveLogic.SetLayer();
            _moveLogic.SetTransform(transform);
            _hp = new HealthPoints(info.MaxHP);
        }

        internal void BindHealthBar(HealthBarManager manager)
        {
            var healthBar = manager.GetHealthBarForTarget(transform);
            _hp.OnChange += healthBar.ChangeHealth;
            _hp.OnNoHP += () => manager.RemoveHealthBar(transform);
            _hp.OnNoHP += SelfDestroy;
        }

        internal void Move()
        {
            StartCoroutine(MoveCoroutine());
        }

        private IEnumerator MoveCoroutine()
        {
            while(_alive)
            {
                _moveLogic.Move();
                yield return null;
            }
        }

        public void SetTarget(Transform target)
        {
            _moveLogic.SetTarget(target);
        }

        [ContextMenu("Destroy enemy")]
        public void SelfDestroy()
        {
            OnDeath?.Invoke(this);
            Destroy(gameObject);
        }

        public void DealDamage(float value)
        {
            _hp.ChangeHP(-value);
        }
    }
}
