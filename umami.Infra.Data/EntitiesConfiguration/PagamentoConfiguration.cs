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
    public class PagamentoConfiguration : IEntityTypeConfiguration<PAGAMENTO>
    {
        public void Configure(EntityTypeBuilder<PAGAMENTO> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.DATA_PAGAMENTO).IsRequired();
            builder.Property(x => x.VALOR_PAGAMENTO).IsRequired().HasPrecision(18, 4);
            builder.Property(x => x.SEQTIPOPAGAMENTO).IsRequired();
            builder.Property(x => x.SEQVENDA).IsRequired();

            builder.HasOne(x => x.VENDA).WithMany(v => v.PAGAMENTO).HasForeignKey(x => x.SEQVENDA).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.TIPOPAGAMENTO).WithMany(p => p.PAGAMENTO).HasForeignKey(x => x.SEQTIPOPAGAMENTO).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
