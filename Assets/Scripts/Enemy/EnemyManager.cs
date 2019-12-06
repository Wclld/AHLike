using System.Collections.Generic;
using UnityEngine;
using AHLike.Data;
using System;

namespace AHLike.Enemy
{
    public class EnemyManager 
    {
        private Transform _enemiesParent;
        private List<Enemy> _enemies = new List<Enemy>();

        public EnemyManager(Transform enemiesParent)
        {
            _enemiesParent = enemiesParent;
        }

        public void BeginMove()
        {
            for (var i = 0; i < _enemies.Count; i++)
            {
                Debug.Log(i);
                _enemies[i].Move();
            }
        }

        public void SetEnemiesOnPositions(Vector3[] positions, EnemyInfo[] enemies, Transform player)
        {
            if(positions.Length > enemies.Length)
            {
                enemies = GrowEnemiesLength(enemies, positions.Length);
            }
            for (var i = 0; i < positions.Length; i++)
            {
                SpawnEnemy(positions[i], enemies[i]);    
            }
        }

        public void SetRandomEnemiesOnPositions(List<Vector3> positions, EnemyInfo[] enemies, Transform player)
        {
            for (var i = 0; i < positions.Count; i++)
            {
                SpawnEnemy(positions[i], enemies[UnityEngine.Random.Range(0,enemies.Length)]);    
            }
            SetTarget(_enemies, player);
        }

        private void SetTarget(List<Enemy> enemies, Transform target)
        {
            for (var i = 0; i < enemies.Count; i++)
            {
                enemies[i].SetTarget(target);
            }
        }

        private void SpawnEnemy(Vector3 pos, EnemyInfo info)
        {
            var enemy = GameObject.Instantiate(info.Prefab, pos, Quaternion.identity, _enemiesParent).
            GetComponent<Enemy>();
            enemy.SetFromInfo(info);
            _enemies.Add(enemy);
        }
        
        private EnemyInfo[] GrowEnemiesLength(EnemyInfo[] enemies, int length)
        {
            var prevLength = enemies.Length;
            Array.Resize<EnemyInfo>(ref enemies, length);
            for (var i = prevLength - 1; i < length; i++)
            {
             enemies[i] = enemies[i % prevLength];   
            }
            return enemies;
        }
    }
}
