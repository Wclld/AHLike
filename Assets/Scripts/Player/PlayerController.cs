using UnityEngine;
using AHLike.Movement;

namespace AHLike.Player
{
    public class PlayerController : MonoBehaviour 
    {
        [SerializeField] MovementController _movement;

        private void Update() 
        {
            _movement.Update();   
        }      
        private void LateUpdate() 
        {
            _movement.LateUpdate();    
        }
    }
}