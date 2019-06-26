using System.Threading.Tasks;

namespace S3.Common
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}