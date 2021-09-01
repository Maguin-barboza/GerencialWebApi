using Microsoft.EntityFrameworkCore;

using Gerencial.WebApi.Models;

namespace Gerencial.WebApi.Data
{
    public class GerencialContext: DbContext
    {
        public GerencialContext(DbContextOptions<GerencialContext> context) : base(context) { }

        public DbSet<Cliente> Tbl_Clientes { get; set; }
        public DbSet<Intervencao> Tbl_Intervencoes { get; set; }
    }
}