using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.Dto;
using Shared.RequestFeatures;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaouleBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OiseauController : ControllerBase
    {
        private readonly IServiceManager _service;
        public OiseauController(IServiceManager serv)
        {
            _service = serv;
        }
        // GET: api/<OiseauController>
        [HttpGet]
        public async Task<IEnumerable<OiseauDto>> GetAsync()
        {
            var oiseaux = await _service.OiseauService.GetOiseauxByAsync(
                new OiseauParameters()
                {
                    NomVernaculaireLike = "psit",
                    NomLike="grive"
                });
            if(oiseaux == null)
            {
                return new List<OiseauDto>();
            }
            return oiseaux;
        }

        // GET api/<OiseauController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OiseauController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OiseauController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OiseauController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
