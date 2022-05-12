using Microsoft.EntityFrameworkCore;

namespace MarcaTexto
{
    public class DatabaseContext : DbContext
    {


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)


        {
         
            Database.EnsureCreated();
           
        }

        public DbSet<Texto> xTexto { get; set; }



    }


}

