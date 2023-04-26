using Shared.Dto;

namespace Service.Contracts
{
    public interface ILieuObservationService
    {
        Task<OiseauDto> GetOiseauAsync(Guid id);
    }
}
