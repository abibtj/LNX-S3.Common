using System.Threading.Tasks;

namespace S3.Common.Fabio
{
    public interface IFabioHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}