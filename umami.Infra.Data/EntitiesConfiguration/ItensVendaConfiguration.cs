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
    public class ItensVendaConfiguration : IEntityTypeConfiguration<ITENSVENDA>
    {
        public void Configure(EntityTypeBuilder<ITENSVENDA> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.QUANT).IsRequired();
            builder.Property(x => x.VALOR).IsRequired();
            builder.Property(x => x.SEQPRODUTO).IsRequired();
            builder.Property(x => x.SEQVENDA).IsRequired();

            builder.HasOne(x => x.VENDA).WithMany(v => v.ITENSVENDA).HasForeignKey(x => x.SEQVENDA).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.PRODUTO).WithMany(p => p.ITENSVENDA).HasForeignKey(x => x.SEQPRODUTO).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
