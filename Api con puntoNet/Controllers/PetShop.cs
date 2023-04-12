using Api_con_puntoNet.Models;
using Microsoft.AspNetCore.Mvc;
using Api_con_puntoNet.Utils;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_con_puntoNet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PetShop : ControllerBase
    {
        private readonly BrandContext _dbContext;
        public PetShop(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }



        // GET: api/<PetShop>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
             if(_dbContext.Clientes == null)
            {
                return NotFound();
            }
            return await _dbContext.Clientes.ToListAsync();
        }
         [HttpGet("{id}")]
       public async Task<ActionResult<Cliente>> Get(int id)
       {
           if (_dbContext.Clientes == null)
           {
               return NotFound();
            }
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if (cliente ==null)
            {
               return NotFound();

            }
            return cliente;
       }

        // GET api/<PetShop>/5
        /* [HttpGet("{id}")]
         public IActionResult Get(int id)
         {
             Cliente clientes = Utils.Utils.clientes.Find(x => x.Id == id);
             return Ok(clientes);
         }*/

        // POST api/<PetShop>
        /**[HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)

        {
            Cliente clientes2 = Utils.Utils.clientes.Find(x => x.Id == cliente.Id);
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
         
        }*/
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }



        // PUT api/<PetShop>/5
        [HttpPut]

        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(cliente).State = EntityState.Modified;


            try{
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteAvailable(id)) 
                    {
                        return NotFound();
                    }else{
                    throw;
                    }
            }
            return Ok();
                }

        private bool ClienteAvailable(int id)
        {
            return (_dbContext.Clientes?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        // DELETE api/<PetShop>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            if(_dbContext.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _dbContext.Clientes.FindAsync(id);
            if(cliente== null)
            {
                return NotFound(id);
            }
            _dbContext.Clientes.Remove(cliente);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
