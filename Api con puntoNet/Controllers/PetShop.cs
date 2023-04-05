using Api_con_puntoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Api_con_puntoNet.Utils;
using Microsoft.CodeAnalysis.Editing;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_con_puntoNet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetShop : ControllerBase
    {
       


        // GET: api/<PetShop>
        [HttpGet]
        public IActionResult Get()
        {
          
             return Ok(Utils.Utils.clientes);
        }

        // GET api/<PetShop>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Cliente clientes = Utils.Utils.clientes.Find(x => x.Id == id);
            return Ok(clientes);
        }

        // POST api/<PetShop>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)

        {
            Cliente clientes2 = Utils.Utils.clientes.Find(x => x.Id == id);
            if (clientes2 ==null)
            {
                Cliente client = new Cliente()
                {
                    Id = cliente.Id,
                    Name = cliente.Name,
                    email = cliente.email,
                    phoneNumber = cliente.phoneNumber,
                };
                Utils.Utils.clientes.Add(client);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
         
        }

        // PUT api/<PetShop>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PetShop>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
