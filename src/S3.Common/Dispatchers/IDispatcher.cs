using System.Threading.Tasks;
using S3.Common.Types;
using S3.Common.Messages;

namespace S3.Common.Dispatchers
{
    public interface IDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}