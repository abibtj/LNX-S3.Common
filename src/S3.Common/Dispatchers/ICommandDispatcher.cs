using System.Threading.Tasks;
using S3.Common.Messages;

namespace S3.Common.Dispatchers
{
    public interface ICommandDispatcher
    {
         Task SendAsync<T>(T command) where T : ICommand;
    }
}