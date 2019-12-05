using System;
using UnityEngine;

namespace AHLike.Rooms
{
    public class RoomManager : MonoBehaviour
    {
        public event Action<RoomInfo> OnRoomLoaded;
        public event Action OnRoomUnloaded;

        private GameObject _currentMap;


        public void LoadRoom(GameObject roomPrefab)
        {
            _currentMap = Instantiate(roomPrefab,Vector3.zero,Quaternion.identity,transform);
            var roomInfo = RoomInfo.GetRoomInfo(_currentMap);
            OnRoomLoaded?.Invoke(roomInfo);
        }
        

        public void UnloadLastRoom()
        {
            if(_currentMap != null)
            {
                Destroy(_currentMap);                
            }
            OnRoomUnloaded?.Invoke();
        }
    }
}
