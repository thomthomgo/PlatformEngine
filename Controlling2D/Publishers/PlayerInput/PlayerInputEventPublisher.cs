using Controlling2D.Interfaces;
using Controlling2D.MonoBehaviours;
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

        public void ListenPlayerInputUpdate(IControllingMonoBehaviour controllingMb)
        {
            controllingMb.NewPlayerInputEvent += RecordPlayerInput;
        }

        public void OnNewPlayerInput(Vector2 playerInput)
        {
            throw new System.NotImplementedException();
        }
    }
}