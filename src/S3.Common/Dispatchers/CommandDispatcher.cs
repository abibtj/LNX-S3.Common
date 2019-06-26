using System.Threading.Tasks;
using Autofac;
using S3.Common.Handlers;
using S3.Common.Messages;
using S3.Common.RabbitMq;

namespace S3.Common.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
            => await _context.Resolve<ICommandHandler<T>>().HandleAsync(command, CorrelationContext.Empty);
    }
}