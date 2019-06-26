using S3.Common.RabbitMq;
using S3.Common.Messages;
using System.Threading.Tasks;

namespace S3.Common.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}