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
        public IActionResult Get(int id)
        {
            var showId = _services.GetById(id);
            if (showId != null)
            {
                return Ok(showId);
            }
            return BadRequest("Id Not Found");
        }

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
        public IActionResult Put(Item item)
        {
            try
            {
                var update = _services.UpdateItem(item);
                if (update)
                {
                    return Ok("success");
                }

                return BadRequest("Id Not Found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
                throw;
            }
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var DeleteItem = _services.DeleteItem(id);
                if (DeleteItem)
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
