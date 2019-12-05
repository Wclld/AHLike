using UnityEngine;
using AHLike.Rooms;
using AHLike.Data;
using AHLike.Player;
using AHLike.Camera;

namespace AHLike.Game
{
    internal class GameLogics : MonoBehaviour
    {
        [SerializeField] GameObject[] _rooms;
        [SerializeField] HeroInfo[] _heroes;
        private RoomManager _roomManager;
        private PlayerManager _playerManager;
        private PlayerFolow _playerFolow;


        private void Start() 
        {
            _playerFolow = PlayerFolow.Instance;

            _playerManager = new PlayerManager();
            _playerManager.OnHeroChanged += x => _playerFolow.SetTarget(x.transform); 
            _playerManager.ChangeHero(_heroes[0]);

            _roomManager = new RoomManager();
            _roomManager.OnRoomLoaded += SetPlayer;
            _roomManager.OnRoomLoaded += SetEnemies;
            _roomManager.LoadRoom(_rooms[0]);
        }

        private void SetPlayer(RoomInfo room)
        {
            _playerManager.SetHeroOnPosition(room.PlayerSpawnPosition);
        }
        private void SetEnemies(RoomInfo room)
        {
            
        }
    }
}
