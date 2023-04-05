﻿using Api_con_puntoNet.Models;
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
        public void Post([FromBody] string value)
        {
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