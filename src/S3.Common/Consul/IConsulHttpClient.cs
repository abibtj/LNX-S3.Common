using System.Threading.Tasks;

namespace S3.Common.Consul
{
    public interface IConsulHttpClient
    {
        Task<T> GetAsync<T>(string requestUri);
    }
}

