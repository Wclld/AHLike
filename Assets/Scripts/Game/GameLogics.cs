using UnityEngine;
using AHLike.Rooms;

namespace AHLike.Game
{
    internal class GameLogics : MonoBehaviour
    {

        [SerializeField] GameObject[] _rooms;
        private RoomManager _roomManager;
        private void Start() 
        {
            _roomManager = new RoomManager();
            _roomManager.LoadRoom(_rooms[0]);
        }
    }
}
