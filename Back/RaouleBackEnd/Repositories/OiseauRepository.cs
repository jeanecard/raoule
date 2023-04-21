using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
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
        /// <summary>
        /// Possibilité de passer également par une requête linq 
        ///  return from oiseau in DbContext.Set<Oiseau>() 
        ///       where 
        ///       oiseau.NomVernaculaire.Contains(param.NomVernaculaireLike) 
        ///       ||
        ///       oiseau.Nom.Contains(param.NomLike)
        ///      select oiseau;
        /// </summary>
        /// <param name="param"></param>
        /// <param name="trackChanges"></param>
        /// <returns></returns>
        public IQueryable<Oiseau> GetOiseaux(OiseauParameters param, bool trackChanges)
        {
            if(String.IsNullOrEmpty(param.NomVernaculaireLike)
                && String.IsNullOrEmpty(param.NomLike))
            {
                return FindAll(trackChanges);
            }
            else if(String.IsNullOrEmpty(param.NomVernaculaireLike))
            {
                return FindByCondition(oiseau => oiseau.Nom.Contains(param.NomLike), 
                trackChanges);
            }
            else if(String.IsNullOrEmpty(param.NomLike))
            {
                return FindByCondition(oiseau => oiseau.NomVernaculaire.Contains(param.NomVernaculaireLike),
                trackChanges);
            }
            else
            {
                return FindByCondition(oiseau =>
                (oiseau.NomVernaculaire.Contains(param.NomVernaculaireLike) && oiseau.Nom.Contains(param.NomLike)),
                trackChanges);
            }
        }
    }
}
