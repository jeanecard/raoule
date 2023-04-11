using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public sealed class ObservationRepository : RepositoryBase<Observation>, IObservationRepository
    {
        public ObservationRepository(DbContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateObservationForLieuAndForOiseau(Guid lieuId, Guid oiseauId, Observation observation)
        {
            observation.LieuId = lieuId;
            observation.OiseauId = oiseauId;
            Create(observation);
        }

        public void DeleteObservation(Observation observation)
        {
            Delete(observation);
        }


        public async Task<Observation?> GetObservationAsync(Guid lieuId, Guid oiseauId, bool trackChanges)
        {
            return await FindByCondition(
                c => c.LieuId.Equals(lieuId) && c.OiseauId.Equals(oiseauId),
                trackChanges)
                      .SingleOrDefaultAsync();
        }

        public async Task<List<Observation>> GetObservationsAsync(Guid? lieuID, Guid? oiseauId, bool trackChanges)
        {
            return await FindAll(trackChanges)
                .ToListAsync();
        }
    }
}
