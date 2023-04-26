using Shared.Dto;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface IOiseauService
    {
        Task<OiseauDto?> GetOiseauByIdAsync(Guid id);
        Task<IReadOnlyCollection<OiseauDto>> GetOiseauxByAsync(OiseauParameters param);

    }
}
