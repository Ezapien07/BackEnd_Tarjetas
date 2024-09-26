using BackEndFETarjeta.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndFETarjeta
{
    public class AppDBContext: DbContext
    {
        public DbSet<TarjetaCredito> tarjetaCredito { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options) 
        {
            
        }
    }
}
