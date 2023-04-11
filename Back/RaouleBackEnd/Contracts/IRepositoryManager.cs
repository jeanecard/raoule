namespace Contracts
{
    public interface IRepositoryManager
    {
        ILieuObservationRepository LieuObservation { get; }
        IObservationRepository Observation { get; }
        IOiseauRepository Oiseau { get; }
        Task SaveAsync();
    }
}
