using UnityEngine;
using Controlling2D.MonoBehaviours;

namespace Controlling2D.Interfaces
{
    public interface IPlayerInputEventPublisher : IControllingEventPublisher
    {
        void RecordPlayerInput(Vector2 playerInput);

        void ListenPlayerInputUpdate(IControllingMonoBehaviour controllingMb);



    }
}