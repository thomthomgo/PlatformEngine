using System.Collections.Generic;
using UnityEngine;

namespace Controlling2D.Interfaces
{
    public interface IVelocityModule
    {
        Vector2 ComputeVelocity(IEnumerable<IControllingEvent> controllingEvents);
    }
}