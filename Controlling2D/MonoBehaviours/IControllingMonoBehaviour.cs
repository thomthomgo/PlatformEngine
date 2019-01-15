using System;
using Controlling2D.Interfaces;
using UnityEngine;

namespace Controlling2D.MonoBehaviours
{
    public delegate void NewPlayerInputEventHandler(Vector2 input);
    public interface IControllingMonoBehaviour
    {
        event NewPlayerInputEventHandler NewPlayerInputEvent;
    }
}