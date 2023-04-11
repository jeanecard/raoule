using Entities;

namespace Contracts
{
    public interface IObservationRepository
    {
        Task<List<Observation>> GetObservationsAsync(
            Guid? lieuID,
            Guid? oiseauId,
            bool trackChanges);
        Task<Observation> GetObservationAsync(
            Guid lieuId,
            Guid oiseauId,
            bool trackChanges);
        void CreateObservationForLieuAndForOiseau(
            Guid lieuId,
            Guid oiseauId,
            Observation observation);
        void DeleteObservation(Observation observation);
    }
}
