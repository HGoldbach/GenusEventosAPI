using GenusEventosApi.Model;
using Microsoft.EntityFrameworkCore;

namespace GenusEventosApi.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }   

        public DbSet<Profissional> Profissionais { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
    }
}
