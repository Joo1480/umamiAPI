using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umami.Domain.Entities;

namespace umami.Infra.Data.EntitiesConfiguration
{
    internal class TipoUsuarioConfiguration : IEntityTypeConfiguration<TIPOUSUARIO>
    {
        public void Configure(EntityTypeBuilder<TIPOUSUARIO> builder) 
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.DESCRICAO).HasMaxLength(100);
        }
    }
}
