using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RaouleBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OiseauController : ControllerBase
    {
        // GET: api/<OiseauController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
