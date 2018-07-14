using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class TipoTelefoneMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<TipoTelefone> type);

        public TipoTelefoneMapBase(EntityTypeBuilder<TipoTelefone> type)
        {
            type.ToTable("TipoTelefone");

            type.Property(t => t.TipoTelefoneId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");


            type.HasKey(d => new { d.TipoTelefoneId, }); 

			CustomConfig(type);

        }
    }
}
