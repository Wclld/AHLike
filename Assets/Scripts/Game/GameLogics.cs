using UnityEngine;
using AHLike.Camera;
using AHLike.Data;
using AHLike.Data.Weapon;
using AHLike.Enemy;
using AHLike.Enemy.Navigation;
using AHLike.Player;
using AHLike.Rooms;

namespace AHLike.Game
{
    internal class GameLogics : MonoBehaviour
    {
        [SerializeField] GameObject[] _rooms;
        [SerializeField] HeroInfo[] _heroes;
        [SerializeField] EnemyInfo[] _enemies;
        [SerializeField] MissileData[] _weapons;
        private RoomManager _roomManager;
        private PlayerManager _playerManager;
        private EnemyManager _enemyManager;
        private PlayerFolow _playerFolow;

        private void Start() 
        {
            _playerFolow = PlayerFolow.Instance;

            
            _roomManager = new RoomManager();
            
            _roomManager.OnRoomLoaded += SetNavMesh;
            _roomManager.OnRoomLoaded += SetPlayer;
            _roomManager.OnRoomLoaded += SetEnemies;
            _roomManager.LoadRoom(_rooms[0]);
        }

        private void SetPlayer(RoomInfo room)
        {
            _playerManager = new PlayerManager();
            _playerManager.ChangeWeapon(_weapons[0]);
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
        private void SetNavMesh(RoomInfo room)
        {
            NavigationManager.RebuildNavMesh(room.MeshSurface);
        }
    }
}
