using Microsoft.EntityFrameworkCore;

namespace BE_CRUDContactos.Models
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options): base(options) 
        { 

        }    

        public DbSet<Contacto> Contactos { get; set; }

    }
}
//https://www.youtube.com/watch?v=TE1Hpi1SSaE