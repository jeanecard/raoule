using Contracts;

namespace Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<ILieuObservationRepository> _lieuObservationRepository;
        private readonly Lazy<IObservationRepository> _observationRepository;
        private readonly Lazy<IOiseauRepository> _oiseauRepository;


        private readonly RepositoryContext _repositoryContext;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
            _lieuObservationRepository = new Lazy<ILieuObservationRepository>(() => new LieuObservationRepository(repositoryContext));
            _observationRepository = new Lazy<IObservationRepository>(() => new ObservationRepository(repositoryContext));
            _oiseauRepository = new Lazy<IOiseauRepository>(() => new OiseauRepository(repositoryContext));
        }
        public ILieuObservationRepository LieuObservation => _lieuObservationRepository.Value;

        public IObservationRepository Observation => _observationRepository.Value;

        public IOiseauRepository Oiseau => _oiseauRepository.Value;

        public async Task SaveAsync()
        {
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
