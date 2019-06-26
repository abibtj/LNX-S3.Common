using System.Threading.Tasks;
using Consul;

namespace S3.Common.Consul
{
    public interface IConsulServicesRegistry
    {
        Task<AgentService> GetAsync(string name);
    }
}