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
    public class ProdutoConfiguration: IEntityTypeConfiguration<PRODUTO>
    {
        public void Configure(EntityTypeBuilder<PRODUTO> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.NOME).HasMaxLength(200).IsRequired();
            builder.Property(x => x.DESCRICAO).HasMaxLength(250);
            builder.Property(x => x.VALOR_VENDA).HasPrecision(18, 2);
            builder.Property(x => x.STATUS).HasColumnType("bit");
        }
    }
}
