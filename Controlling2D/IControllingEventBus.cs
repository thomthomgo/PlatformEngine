namespace Controlling2D
{
    public interface IControllingEventBus
    {
        void RecordPublisher(IControllingEventPublisher publisher);
    }
}