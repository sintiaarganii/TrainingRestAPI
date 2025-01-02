using Microsoft.AspNetCore.Mvc;
using Training2.Models.DB;
using Training2.services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Training2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemServices _services;
        private object _context;
        private Item item;


        public ItemController(ItemServices services)
        {
            _services = services;
        }

        // GET: api/<ItemController>
        [HttpGet]
        public IActionResult Get()
        {
            var itemList = _services.GetListItem();
            return Ok(itemList);
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
           
        //}

        // POST api/<ItemController>
        [HttpPost]
        public IActionResult Post(Item item)
        {
            var insertItem = _services.AddItem(item);
            if (insertItem)
            {
                return Ok("insert Customer success");
            }
            return BadRequest("insert Customer failed");
        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
