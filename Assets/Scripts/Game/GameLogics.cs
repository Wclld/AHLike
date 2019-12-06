﻿using UnityEngine;
using AHLike.Camera;
using AHLike.Data;
using AHLike.Enemy;
using AHLike.Player;
using AHLike.Rooms;

namespace AHLike.Game
{
    internal class GameLogics : MonoBehaviour
    {
        [SerializeField] GameObject[] _rooms;
        [SerializeField] HeroInfo[] _heroes;
        [SerializeField] EnemyInfo[] _enemies;
        private RoomManager _roomManager;
        private PlayerManager _playerManager;
        private EnemyManager _enemyManager;
        private PlayerFolow _playerFolow;


        private void Start() 
        {
            _playerFolow = PlayerFolow.Instance;

            _roomManager = new RoomManager();
            _roomManager.OnRoomLoaded += SetPlayer;
            _roomManager.OnRoomLoaded += SetEnemies;
            _roomManager.LoadRoom(_rooms[0]);
        }

        private void SetPlayer(RoomInfo room)
        {
            _playerManager = new PlayerManager();
            _playerManager.OnHeroChanged += x => _playerFolow.SetTarget(x.transform); 
            _playerManager.ChangeHero(_heroes[0]);
            _playerManager.SetHeroOnPosition(room.PlayerSpawnPosition);
        }
        private void SetEnemies(RoomInfo room)
        {
            _enemyManager = new EnemyManager(new GameObject("Enemies").transform);
            var hero = _playerManager.GetHeroGO().transform;
            _enemyManager.SetRandomEnemiesOnPositions(room.EnemySpawnPositions, _enemies, hero);
            _enemyManager.BeginMove();
        }
    }
}
