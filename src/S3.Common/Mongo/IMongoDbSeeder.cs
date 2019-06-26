using System.Threading.Tasks;

namespace S3.Common.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}