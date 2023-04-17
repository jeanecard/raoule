using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.RequestFeatures;

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

        public IQueryable<Oiseau> GetOiseaux(OiseauParameters param, bool trackChanges)
        {
            if(String.IsNullOrEmpty(param.NomVernaculaireLike)
                && String.IsNullOrEmpty(param.NomLike))
            {
                return FindAll(trackChanges);

            }
            else
            {
                return FindByCondition(oiseau =>test(oiseau, param), trackChanges);
            }
           
        }
        private bool test(Oiseau oiseau, OiseauParameters param)
        {
            if (param?.NomVernaculaireLike == null || param?.NomLike == null)
                throw new ArgumentNullException("Param");
            return oiseau.NomVernaculaire.Contains(param.NomVernaculaireLike)
                || oiseau.Nom.Contains(param.NomLike);
        }
    }
}
