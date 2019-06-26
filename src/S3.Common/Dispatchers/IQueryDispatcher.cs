using System.Threading.Tasks;
using S3.Common.Types;

namespace S3.Common.Dispatchers
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}