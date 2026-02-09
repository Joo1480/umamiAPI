using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;

namespace umami.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { }
        public DbSet<TIPOUSUARIO> TIPOUSUARIO {  get; set; }
        public DbSet<USUARIO> USUARIO {  get; set; }
        public DbSet<PRODUTO> PRODUTO {  get; set; }
        public DbSet<VENDA> VENDA {  get; set; }
        public DbSet<ITENSVENDA> ITENSVENDA {  get; set; }
        public DbSet<TIPOPAGAMENTO> TIPOPAGAMENTO {  get; set; }
        public DbSet<PAGAMENTO> PAGAMENTO {  get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
