using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class TipoEnderecoMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<TipoEndereco> type);

        public TipoEnderecoMapBase(EntityTypeBuilder<TipoEndereco> type)
        {
            type.ToTable("TipoEndereco");

            type.Property(t => t.TipoEnderecoId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(150)");


            type.HasKey(d => new { d.TipoEnderecoId, }); 

			CustomConfig(type);

        }
    }
}
