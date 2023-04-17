using Entities;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IOiseauRepository
    {
        IQueryable<Oiseau> GetOiseaux(OiseauParameters param, bool trackChanges);
        Task<Oiseau?> GetOiseauAsync(Guid id, bool trackChanges);
        void CreateOiseau(Oiseau oiseau);
        void DeleteOiseau(Oiseau oiseau);
    }
}
