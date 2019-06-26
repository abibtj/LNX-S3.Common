using S3.Common.RabbitMq;
using S3.Common.Messages;
using System.Threading.Tasks;

namespace S3.Common.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}