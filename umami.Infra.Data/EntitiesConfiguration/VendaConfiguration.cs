using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;

namespace umami.Infra.Data.EntitiesConfiguration
{
    public class VendaConfiguration : IEntityTypeConfiguration<VENDA>
    {
        public void Configure(EntityTypeBuilder<VENDA> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.DATA_VENDA).IsRequired();
            builder.Property(x => x.STATUS).IsRequired();
            builder.Property(x => x.SEQUSUARIO).IsRequired();

            builder.HasOne(x => x.USUARIO).WithMany(u => u.VENDAS)
                .HasForeignKey(x => x.SEQUSUARIO).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
