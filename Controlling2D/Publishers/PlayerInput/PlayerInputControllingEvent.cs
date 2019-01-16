using Controlling2D.Interfaces;
using UnityEngine;

namespace Controlling2D.Publishers.PlayerInput
{
    public class PlayerInputControllingEvent : IControllingEvent
    {
        private readonly Vector2 _playerInput = new Vector2();

        public PlayerInputControllingEvent(Vector2 playerInput)
        {
            _playerInput = playerInput;
        }

        public Vector2 GetInput()
        {
            return _playerInput;
        }
    
    }
}