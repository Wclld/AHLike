using AHLike.Data;
using UnityEngine;

namespace AHLike.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private HeroInfo _currentHero;
        private GameObject _heroGO;


        public void ChangeHero(HeroInfo hero)
        {
            _currentHero = hero;
            if(hero.Prefab != null)
            {
                _heroGO = Instantiate(hero.Prefab,Vector3.zero,Quaternion.identity,transform);
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
                Destroy(_heroGO);
            }
        }
    }
}