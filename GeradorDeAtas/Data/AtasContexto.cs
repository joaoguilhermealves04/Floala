using GeradorDeAtas.Models;
using Microsoft.EntityFrameworkCore;

namespace GeradorDeAtas.Data
{
    public class AtasContexto: DbContext
    {
        public AtasContexto(DbContextOptions<AtasContexto>options): base(options)
        {
            
        }

        public DbSet<Atas> Atas { get; set; }
    }
}
