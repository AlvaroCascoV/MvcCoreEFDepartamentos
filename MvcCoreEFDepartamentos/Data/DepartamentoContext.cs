using Microsoft.EntityFrameworkCore;
using MvcCoreEFDepartamentos.Models;

namespace MvcCoreEF.Data
{
    public class DepartamentoContext : DbContext
    {
        public DepartamentoContext(DbContextOptions<DepartamentoContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
