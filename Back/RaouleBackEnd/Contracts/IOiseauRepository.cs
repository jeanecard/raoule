using Entities;

namespace Contracts
{
    public interface IOiseauRepository
    {
        Task<List<Oiseau>> GetOiseauxAsync(bool trackChanges);
        Task<Oiseau?> GetOiseauAsync(Guid id, bool trackChanges);
        void CreateOiseau(Oiseau oiseau);
        void DeleteOiseau(Oiseau oiseau);
    }
}
