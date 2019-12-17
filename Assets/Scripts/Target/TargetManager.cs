﻿using System.Collections.Generic;
using UnityEngine;

namespace AHLike.Target
{
    public class TargetManager 
    {
        public Transform Player => _player;
        private HashSet<Transform> _enemies;    
        private Transform _player;

        public TargetManager()
        {
            _enemies = new HashSet<Transform>();
        }

        
        public void AddEnemy(Transform enemy)
        {
            if(!_enemies.Contains(enemy))
            {
                _enemies.Add(enemy);
            }
        }

        public void RemoveEnemy(Transform enemy)
        {
            if(_enemies.Contains(enemy))
            {
                _enemies.Remove(enemy);
            }
        }

        public void SetPlayer(Transform player)
        {
            _player = player;
        }

        public Transform GetClosestEnemy()
        {
            Transform result = null;
            var minDistance = -1f;

            foreach (var enemy in _enemies)
            {
                var currentDistance = Vector3.Distance(enemy.position, _player.position); 
                if(minDistance > currentDistance || minDistance < 0)
                {
                    minDistance = currentDistance;
                    result = enemy;
                }
            }
            return result;
        }
    } 
}
