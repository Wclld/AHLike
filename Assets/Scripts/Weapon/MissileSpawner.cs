using System.Collections.Generic;
using UnityEngine;
using AHLike.Data.Weapon;

namespace AHLike.Weapon
{
    public class MissileSpawner 
    {
        private const int POOL_INCREASE_SIZE = 10;
        public MissileData CurrentWeapon => _currentWeapon;
        MissileData _currentWeapon;
        Stack<GameObject> _missilePool;

        public void SetWeapon(MissileData missile)
        {
            _currentWeapon = missile;
        }

        public Missile GetMissile()
        {
            if(_missilePool == null || _missilePool.Count > 0)
            {
                PopulateMissilePool();
            }
            return _missilePool.Pop().GetComponent<Missile>();
        }

        public void HideMissile(GameObject missile)
        {
            missile.SetActive(false);
            _missilePool.Push(missile);
        }

        private void PopulateMissilePool()
        {
            if (_missilePool == null)
            {
                _missilePool = new Stack<GameObject>();
            }
            for(var i = 0; i < POOL_INCREASE_SIZE; i++)
            {
                _missilePool.Push(InstantiateNewMissile());
            }
        }

        private GameObject InstantiateNewMissile()
        {
            var result = GameObject.Instantiate(_currentWeapon.MissilePrefab);
            return result;
        }


        private void AddModifier(IModifier modifier)
        {
            
        }
    }
}