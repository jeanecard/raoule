using Contracts;
using MapsterMapper;
using Microsoft.Extensions.Logging;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IOiseauService> _oiseauService;
        public ServiceManager(IRepositoryManager repo)
        {
            _oiseauService = new Lazy<IOiseauService>(() => new OiseauService( repo));
        }
        public IOiseauService OiseauService => _oiseauService.Value;
    }
}
