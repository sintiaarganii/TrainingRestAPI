using Microsoft.AspNetCore.Mvc;
using Training2.Models.DB;
using Training2.services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerServices _services;
        private object _context;
        private Customer customer;

        public CustomerController(CustomerServices services)
        {
            _services = services;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            var customerList = _services.GetListCustomers();
            return Ok(customerList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var showId = _services.GetById(id);
            if (showId != null)
            {
                return Ok(showId);
            }
            return BadRequest("Id Not Found");
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post(Customer customer) //lebih fleksible 
        {
            var insertCustomer = _services.createCustomer(customer);
            if (insertCustomer)
            {
                return Ok("insert Customer success");
            }
            return BadRequest("insert Customer failed");
            //return StatusCode(StatusCodes.) cari apa aja yg ada di statusCodes
        }

        
        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Customer customer)
        {
            try {
                var updateCustomer = _services.UpdateCustomer(customer);
                if (updateCustomer)
                {
                    return Ok("success");
                }

                return BadRequest("failed");
            }
            catch (Exception ex) {
                return BadRequest(ex.Message.ToString());
                throw;
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var DeleteCust = _services.DeleteCustomer(id);
                if (DeleteCust)
                {
                    return Ok("success");
                }
                return BadRequest("Id Not Found");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
