using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public sealed class LieuObservationRepository : RepositoryBase<LieuObservation>, ILieuObservationRepository
    {
        public LieuObservationRepository(DbContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateLieuObservation(LieuObservation lieu)
        {
            Create(lieu);
        }

        public void DeleteLieuObservation(LieuObservation lieu)
        {
            Delete(lieu);
        }

        public async Task<LieuObservation> GetLieuObservationAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(
                c => c.Id.Equals(id),
                trackChanges)
                      .SingleOrDefaultAsync();
        }

        public async Task<List<LieuObservation>> GetLieuObservationsAsync(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .ToListAsync();
        }
    }
}
