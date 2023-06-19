using Microsoft.EntityFrameworkCore;

namespace Prueba_modelo_existente.Models
{
    public class PruebaDbContext: DbContext
    
    {
        public PruebaDbContext(DbContextOptions<PruebaDbContext> options)
            : base(options)
        {

        }
    }
}


