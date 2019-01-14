using System.Linq;
using Controlling2D.ControllingEventBus;
using Controlling2D.Interfaces;
using NUnit.Framework;
using NSubstitute;

namespace ControllingTests
{
    [TestFixture]
    public class ControllingEventBusTests
    {
        private IControllingEventBus _eventBus;
        [SetUp]
        public void InitTest()
        {
            _eventBus = new ControllingEventBus();
        }
        
        [Test]
        public void Given_no_registered_publishers_GetPublications_should_return_empty_enumerable_of_controlling_events()
        {
            var publications = _eventBus.GetPublications().ToArray();
            Assert.That(publications.Count(), Is.EqualTo(0));
        }
        [Test]
        public void Given_registered_publishers_GetPublications_should_retrieve_their_publicated_controlling_events()
        {
            var publisher = Substitute.For<IControllingEventPublisher>();
            var eventToPublish = Substitute.For<IControllingEvent>();
            publisher.PublishEvent().Returns(eventToPublish);
            
            _eventBus.RegisterPublisher(publisher);
            
            var publications = _eventBus.GetPublications().ToArray();
            
            publisher.Received(1).PublishEvent();
            Assert.That(publications.Count(), Is.EqualTo(1));
            Assert.That(publications.ElementAt(0), Is.EqualTo(eventToPublish));   
        }
    }
}