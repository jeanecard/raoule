using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public sealed class OiseauRepository : RepositoryBase<Oiseau>, IOiseauRepository
    {
        public OiseauRepository(DbContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOiseau(Oiseau oiseau)
        {
            Create(oiseau);
        }

        public void DeleteOiseau(Oiseau oiseau)
        {
            Delete(oiseau);
        }

        public async Task<Oiseau?> GetOiseauAsync(Guid id, bool trackChanges)
        {
            return await FindByCondition(
                c => c.Id.Equals(id),
                trackChanges)
                      .SingleOrDefaultAsync();
        }

        public async Task<List<Oiseau>> GetOiseauxAsync(bool trackChanges)
        {
            var result =  await FindAll(trackChanges).ToListAsync();
            if(result == null)
            {
                result = new List<Oiseau>();
            }
            return result;
        }
    }
}
