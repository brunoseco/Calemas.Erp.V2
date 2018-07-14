using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class CidadeMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Cidade> type);

        public CidadeMapBase(EntityTypeBuilder<Cidade> type)
        {
            type.ToTable("Cidade");

            type.Property(t => t.CidadeId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.UF).HasColumnName("UF").HasColumnType("varchar(2)");


            type.HasKey(d => new { d.CidadeId, }); 

			CustomConfig(type);

        }
    }
}
