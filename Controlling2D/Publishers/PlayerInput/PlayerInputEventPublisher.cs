using Controlling2D.Interfaces;
using UnityEngine;

namespace Controlling2D.Publishers.PlayerInput
{
    public class PlayerInputEventPublisher : IPlayerInputEventPublisher
    {
        private Vector2 _lastInput;

        public PlayerInputEventPublisher()
        {
            _lastInput = new Vector2(0,0);
        }
        
        public IControllingEvent PublishEvent()
        {
            var inputEvent = new PlayerInputControllingEvent(_lastInput);
            return inputEvent;
        }

        public void RecordPlayerInput(Vector2 playerInput)
        {
            _lastInput = playerInput;
        }
    }
}