using Microsoft.Extensions.Configuration;
using TabooReloaded.Shared.Services;

namespace TabooReloaded.Services
{
    public class MongoService : IDatabaseService
    {
        private readonly IConfiguration _config;
        public MongoService(IConfiguration config)
        {
            _config = config;
        }

        public Task<bool> ConnectAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DisconnectAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetTabooWordAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetTabooWordListAsync(int n)
        {
            throw new NotImplementedException();
        }
    }
}
