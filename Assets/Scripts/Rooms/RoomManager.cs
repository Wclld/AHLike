using System;
using UnityEngine;

namespace AHLike.Rooms
{
    public class RoomManager
    {
        public event Action<RoomInfo> OnRoomLoaded;
        public event Action OnRoomUnloaded;

        private GameObject _currentMap;


        public void LoadRoom(GameObject roomPrefab)
        {
            _currentMap = GameObject.Instantiate(roomPrefab,Vector3.zero,Quaternion.identity);
            var roomInfo = RoomInfo.GetRoomInfo(_currentMap);
            OnRoomLoaded?.Invoke(roomInfo);
        }
        

        public void UnloadLastRoom()
        {
            if(_currentMap != null)
            {
                GameObject.Destroy(_currentMap);                
            }
            OnRoomUnloaded?.Invoke();
        }
    }
}
