using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestItem.Managers;
using RestItem.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestItem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsManager _manager = new ItemsManager();
        // GET: api/<ItemsController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Item> Get([FromQuery] string name, [FromQuery] string sortBy)
        {
            return _manager.GetAll(name,sortBy);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Item> Get(int id)
        {
            Item item = _manager.GetById(id);
            if (item == null) return NotFound("Not found");
            return Ok(item);
        }

        // POST api/<ItemsController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Item> Post([FromBody] Item value)
        {
            try
            {
                Item item = _manager.Add(value);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + value.Id;
                return Created(uri,item);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Item> Put(int id, [FromBody] Item value)
        {
           return _manager.Update(id,value);
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public void Delete(int id)
        {
            _manager.Delete(id);
        }
    }
}
