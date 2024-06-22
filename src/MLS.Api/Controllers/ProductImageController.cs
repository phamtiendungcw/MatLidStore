using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers
{
    public class ProductImageController : MatLidStoreBaseController
    {
        // GET: api/<ProductImageController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductImageController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductImageController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductImageController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductImageController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}