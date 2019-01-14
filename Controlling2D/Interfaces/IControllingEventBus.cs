using System.Collections.Generic;

namespace Controlling2D.Interfaces
{
    public interface IControllingEventBus
    {
        void RegisterPublisher(IControllingEventPublisher publisher);

        IEnumerable<IControllingEvent> GetPublications();
    }
}