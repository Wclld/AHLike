using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AHLike.Rooms
{
    public class RoomInfo
    {
        private const string ENEMY_SPAWNPOINT_PATH = "SpawnPoints/EnemySpawnPoints"; 
        private const string PLAYER_SPAWNPOINT_PATH = "SpawnPoints/PlayerSpawnPoint";

        public List<Vector3> EnemySpawnPositions;
        public Vector3 PlayerSpawnPosition;
        public NavMeshSurface MeshSurface;

        private RoomInfo()
        {
        }

        public static RoomInfo GetRoomInfo(GameObject room)
        {
            RoomInfo result = new RoomInfo()
            {
                EnemySpawnPositions = GetEnemySpawnPositions(room),
                PlayerSpawnPosition = GetPlayerSpawnPosition(room),
                MeshSurface = GetNavMeshSurface(room)
            };
            
            return result;
        }

        private static NavMeshSurface GetNavMeshSurface(GameObject room)
        {
            return room.GetComponentInChildren<NavMeshSurface>();
        }

        private static List<Vector3> GetEnemySpawnPositions(GameObject room)
        {
            var result = new List<Vector3>();
            if (room != null) 
            {
                var spawnpoint = room.transform.Find(ENEMY_SPAWNPOINT_PATH);
                if (spawnpoint != null)
                {
                    for (var i = 0; i < spawnpoint.childCount; i++)
                    {
                        result.Add(spawnpoint.GetChild(i).position);
                    }
                }
            }
            return result;
        }
        private static Vector3 GetPlayerSpawnPosition(GameObject room)
        {
            var result = Vector3.zero;
            if(room)
            {
                var spawnpoint = room.transform.Find(PLAYER_SPAWNPOINT_PATH);
                if(spawnpoint)
                {
                    result = spawnpoint.position;
                }
            }
            return result;
        }
    }
}
