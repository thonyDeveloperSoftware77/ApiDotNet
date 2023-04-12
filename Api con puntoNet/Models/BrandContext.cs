using Api_con_puntoNet.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Api_con_puntoNet.Models
{
    public class BrandContext: DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> options): base(options) { 
        

        }

        public DbSet<Cliente> Clientes { get; set; }



    }
}
