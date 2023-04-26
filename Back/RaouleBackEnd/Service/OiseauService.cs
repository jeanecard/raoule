using Contracts;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using Shared.Dto;
using Shared.RequestFeatures;

namespace Service
{
    public class OiseauService : IOiseauService
    {
        private readonly IRepositoryManager _repos;
        public OiseauService(
            IRepositoryManager repos) 
        {
            _repos = repos;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="trackChange"></param>
        /// <returns></returns>
        public async Task<OiseauDto?> GetOiseauByIdAsync(Guid id)
        {
            var oiseau = await _repos.Oiseau.GetOiseauAsync(id, false);
            if(oiseau == null)
            {
                return null;
            }
            return oiseau.Adapt<OiseauDto>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IReadOnlyCollection<OiseauDto>> GetOiseauxByAsync(OiseauParameters param)
        {
            var oiseaux = _repos.Oiseau.GetOiseaux(param, false);
            return await oiseaux.ProjectToType<OiseauDto>().ToListAsync();
        }

    }
}