using System;
using System.Collections.Generic;
using System.Linq;
using Controlling2D.Interfaces;
using Controlling2D.Publishers.PlayerInput;
using Controlling2D.VelocityModules;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace ControllingTests
{
    [TestFixture]
    public class HorizontalMoveVelocityModuleTests
    {
        private float _xSpeed;
        private HorizontalMoveVelocityModule _velocityModule;
        private Vector2 _playerInput;

        [SetUp]
        public void InitTests()
        {
            _xSpeed = 2.5f;
            _velocityModule = new HorizontalMoveVelocityModule(_xSpeed);
            _playerInput = new Vector2(2, 9);
        }
        [Test]
        public void Given_playerInputControllingEvent_and_x_speed_should_return_expected_velocity_vector()
        {
            
            var playerInputEvent = new PlayerInputControllingEvent(_playerInput);

            var controllingEvents = new List<IControllingEvent>();
            controllingEvents.Add(playerInputEvent);
            
            var velocity = _velocityModule.ComputeVelocity(controllingEvents);
            var expectedVelocity = new Vector2(_playerInput.x * _xSpeed, 0);
            
            Assert.That(velocity, Is.EqualTo(expectedVelocity));
        }
        
        [Test]
        public void Given_no_playerInputControllingEvent_should_return_empty_velocity_vector()
        {
            var controllingEvents = new List<IControllingEvent>();
            
            var velocity = _velocityModule.ComputeVelocity(controllingEvents);
            var expectedVelocity = new Vector2(0,0);
            
            Assert.That(velocity, Is.EqualTo(expectedVelocity));
        }

        [Test]
        public void Given_more_than_one_playerInputControllingEvent_should_throw()
        {
            var playerInputEvent = new PlayerInputControllingEvent(_playerInput);
            var controllingEvents = Enumerable.Repeat(playerInputEvent, 2);

            Assert.Throws<ArgumentException>(() => _velocityModule.ComputeVelocity(controllingEvents));
        }
    }
}