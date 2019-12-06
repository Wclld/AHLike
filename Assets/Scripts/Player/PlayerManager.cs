using System;
using AHLike.Data;
using UnityEngine;

namespace AHLike.Player
{
    public class PlayerManager
    {
        public event Action<GameObject> OnHeroChanged;
        private HeroInfo _currentHero;
        private GameObject _heroGO;

        public GameObject GetHeroGO()
        {
            return _heroGO;
        }
        public void ChangeHero(HeroInfo hero)
        {
            _currentHero = hero;
            if(hero.Prefab != null)
            {
                _heroGO = GameObject.Instantiate(hero.Prefab,Vector3.zero,Quaternion.identity);
                OnHeroChanged?.Invoke(_heroGO);
            }
        }

        public void SetHeroOnPosition(Vector3 position)
        {
            if(_heroGO != null)
            {
                _heroGO.transform.position = position;
            }
        }

        public void RemoveHero()
        {
            if(_heroGO != null)
            {
                GameObject.Destroy(_heroGO);
            }
        }
    }
}