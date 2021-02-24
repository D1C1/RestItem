using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IEnumerable<Item> Get([FromQuery] string name, [FromQuery] string sortBy)
        {
            return _manager.GetAll(name,sortBy);
        }

        // GET api/<ItemsController>/5
        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return _manager.GetById(id);
        }

        // POST api/<ItemsController>
        [HttpPost]
        public void Post([FromBody] Item value)
        {
            _manager.Add(value);
        }

        // PUT api/<ItemsController>/5
        [HttpPut("{id}")]
        public Item Put(int id, [FromBody] Item value)
        {
           return _manager.Update(id,value);
        }

        // DELETE api/<ItemsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _manager.Delete(id);
        }
    }
}
