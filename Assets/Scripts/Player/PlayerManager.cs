using System;
using System.Collections;
using UnityEngine;
using AHLike.Data;
using AHLike.Data.Weapon;
using AHLike.Movement;
using AHLike.Weapon;

namespace AHLike.Player
{
    public class PlayerManager
    {
        public event Action<GameObject> OnHeroChanged;
        private GameObject _heroGO;
        private HeroInfo _currentHero;
        private MovementInput _input;
        private MissileSpawner _missileSpawner = new MissileSpawner();
        private MonoBehaviour _heroController;
        private Coroutine _attackCoroutine;

        public GameObject GetHeroGO()
        {
            return _heroGO;
        }
        public void ChangeHero(HeroInfo hero)
        {
            _currentHero = hero;

            if(hero.Prefab != null)
            {
                _heroGO = GameObject.Instantiate(hero.Prefab, Vector3.zero, Quaternion.identity);
                InitController(_heroGO);
                OnHeroChanged?.Invoke(_heroGO);
            }
        }
        public void ChangeWeapon(MissileData missile)
        {
            _missileSpawner.SetWeapon(missile);
        }

        private void InitController(GameObject hero)
        {
            var controller = _heroGO.GetComponent<PlayerController>();
            if(_input == null)
            {
                InitInput();
            }
            _input.ClearEvents();
            controller.Init(_input);
            _heroController = controller;
            SubscribeOnInput();
            controller.StartCoroutine(AttackCoroutine());
        }

        private void SubscribeOnInput()
        {
            _input.OnInputEnded += StartAttack;
            _input.OnInputEnded += EndAttack;
        }

        private void StartAttack()
        {
            //_attackCoroutine = _heroController.StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            var waitTime = new WaitForSeconds(1 / _missileSpawner.CurrentWeapon.AttackSpeed);
            while(_heroController != null)
            {
                Debug.Log("Attacking");
                var missile = _missileSpawner.GetMissile();
                missile.transform.position = _heroController.transform.position;
                missile.Init(_missileSpawner.CurrentWeapon,new Vector3(0,1,0));
                yield return waitTime;
            }
        }

        private void EndAttack()
        {
            //_heroController.StopCoroutine(_attackCoroutine);
        }

        private void InitInput()
        {
#if UNITY_EDITOR
            _input = new KeyboarInput();
#else
            _input = new JoystickInput();
#endif
            _input.OnInputBegin += () => {};
            _input.OnInputEnded += () => {};
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
