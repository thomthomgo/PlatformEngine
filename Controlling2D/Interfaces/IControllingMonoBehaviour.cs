using UnityEngine;

namespace Controlling2D.Interfaces
{
    public delegate void NewPlayerInputEventHandler(Vector2 input);
    public interface IControllingMonoBehaviour
    {
        event NewPlayerInputEventHandler NewPlayerInputEvent;
    }
}