using UnityEngine;

namespace Controlling2D.Interfaces
{
    public interface IPlayerInputEventPublisher : IControllingEventPublisher
    {
        void RecordPlayerInput(Vector2 playerInput);
    }
}