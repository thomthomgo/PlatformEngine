using System.Collections.Generic;
using Controlling2D.Interfaces;

namespace Controlling2D.ControllingEventBus
{
    public class ControllingEventBus : IControllingEventBus
    {
        private List<IControllingEventPublisher> _publishers;

        public ControllingEventBus()
        {
            _publishers = new List<IControllingEventPublisher>();
        }
        public void RegisterPublisher(IControllingEventPublisher publisher)
        {
            _publishers.Add(publisher);
        }

        public IEnumerable<IControllingEvent> GetPublications()
        {
            List<IControllingEvent> publications = new List<IControllingEvent>();
            foreach (var publisher in _publishers)
            {
                var publication = publisher.PublishEvent();
                publications.Add(publication);
            }
            return publications;
        }
    }
}