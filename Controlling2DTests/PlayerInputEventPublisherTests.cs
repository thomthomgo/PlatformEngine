using Controlling2D.Publishers.PlayerInput;
using NUnit.Framework;
using UnityEngine;
using System;
using System.ComponentModel;
using Controlling2D.MonoBehaviours;
using NSubstitute;

namespace ControllingTests
{
    [TestFixture]
    public class PlayerInputEventPublisherTests
    {
        [Test]
        public void Given_no_input_recorded_should_publish_input_event_with_zeroed_values()
        {
            var publisher = new PlayerInputEventPublisher();
            var publication = publisher.PublishEvent();
            var inputEvent = publication as PlayerInputControllingEvent;
            
            Assert.That(inputEvent, Is.Not.Null);

            var recordedInput = inputEvent.GetInput();
            
            Assert.That(recordedInput, Is.EqualTo(new Vector2(0,0)));
        }
        
        [Test]
        public void Given_recorded_input_should_publish_last_recorded_input()
        {
            var publisher = new PlayerInputEventPublisher();
           
            var input1 = new Vector2(1,0);
            var input2 = new  Vector2(4, 2);
            
            publisher.RecordPlayerInput(input1);
            publisher.RecordPlayerInput(input2);
            
            var publication = publisher.PublishEvent();
            var inputEvent = publication as PlayerInputControllingEvent;
            var recordedInput = inputEvent.GetInput();
            
            Assert.That(inputEvent, Is.Not.Null);
            Assert.That(recordedInput, Is.EqualTo(input2));
        }

        [Test]
        public void Given_a_subscription_to_a_controlling_mb_and_new_player_input_event_should_record_them()
        {
            var publisher = new PlayerInputEventPublisher();
            var controllingMb = Substitute.For<IControllingMonoBehaviour>();
            var playerInput = new Vector2(32,14);
            
            publisher.ListenPlayerInputUpdate(controllingMb);

            controllingMb.NewPlayerInputEvent += Raise.Event<NewPlayerInputEventHandler>(playerInput);
            
            var publication = publisher.PublishEvent();
            var inputEvent = publication as PlayerInputControllingEvent;
            
            Assert.That(inputEvent, Is.Not.Null); 
           
            var recordedInput = inputEvent.GetInput();
           
            Assert.That(recordedInput, Is.EqualTo(playerInput));
        }
    }
}