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
    public class UsuarioConfiguration : IEntityTypeConfiguration<USUARIO>
    {
        public void Configure(EntityTypeBuilder<USUARIO> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.EMAIL).HasMaxLength(200).IsRequired();
            builder.Property(x => x.NOME).HasMaxLength(250).IsRequired();
            builder.Property(x => x.CELULAR).HasMaxLength(20);
            builder.Property(x => x.CEP).HasMaxLength(10);
            builder.Property(x => x.NUMENDERECO).HasMaxLength(50);
            builder.Property(x => x.COMPLEMENTO).HasMaxLength(50);
            builder.Property(x => x.CPF).HasMaxLength(50);
            builder.Property(x => x.SEQTIPOUSUARIO).HasMaxLength(10).IsRequired();

            builder.HasOne(x => x.TIPOUSUARIO).WithMany(x => x.USUARIO)
                .HasForeignKey(x => x.SEQTIPOUSUARIO).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
