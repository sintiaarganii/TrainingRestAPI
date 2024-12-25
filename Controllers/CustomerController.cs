using Microsoft.AspNetCore.Mvc;
using Training2.services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerServices _services;
        public CustomerController(CustomerServices services)
        {
            _services = services;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            //return new string[] { "value1", "value2" };
            var customerList = _services.GetListCustomers();
            return Ok(customerList);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
