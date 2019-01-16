using System;
using System.Collections.Generic;
using System.Linq;
using Controlling2D.Interfaces;
using Controlling2D.Publishers.PlayerInput;
using UnityEngine;

namespace Controlling2D.VelocityModules
{
    public class HorizontalMoveVelocityModule : IVelocityModule
    {
        private float _xSpeed;
        
        public HorizontalMoveVelocityModule(float xSpeed)
        {
            _xSpeed = xSpeed;
        }
        
        public Vector2 ComputeVelocity(IEnumerable<IControllingEvent> controllingEvents)
        {
            var velocity = new Vector2(0,0);
            var inputControllingEvent = controllingEvents.Where(ce => ce is PlayerInputControllingEvent).ToArray();

            if (!inputControllingEvent.Any())
            {
                return velocity;
            }
            if (inputControllingEvent.Count() > 1)
            {
                throw new ArgumentException("Cannot deal with more than 1 input controlling Event");
            }

            var playerInputControllingEvent = inputControllingEvent.SingleOrDefault() as PlayerInputControllingEvent;

            var playerInput = playerInputControllingEvent.GetInput();

            velocity.x = playerInput.x * _xSpeed;
            velocity.y = 0;
            return velocity;
        }        
    }
}