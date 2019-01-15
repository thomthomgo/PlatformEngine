using UnityEngine;

namespace Controlling2D.MonoBehaviours
{
    public class ControllingMonoBehaviour : UnityEngine.MonoBehaviour, IControllingMonoBehaviour
    {
        private void Update()
        {
            NewPlayerInputEvent?.Invoke(new Vector2(1,2));
        }


        public event NewPlayerInputEventHandler NewPlayerInputEvent;
    }
}