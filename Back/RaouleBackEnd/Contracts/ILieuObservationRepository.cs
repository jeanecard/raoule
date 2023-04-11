using Entities;

namespace Contracts
{
    public interface ILieuObservationRepository
    {
        Task<List<LieuObservation>> GetLieuObservationsAsync(bool trackChanges);
        Task<LieuObservation?> GetLieuObservationAsync(Guid id, bool trackChanges);
        void CreateLieuObservation(LieuObservation lieu);
        void DeleteLieuObservation(LieuObservation lieu);
    }
}
