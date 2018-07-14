using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class TipoEmailMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<TipoEmail> type);

        public TipoEmailMapBase(EntityTypeBuilder<TipoEmail> type)
        {
            type.ToTable("TipoEmail");

            type.Property(t => t.TipoEmailId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");


            type.HasKey(d => new { d.TipoEmailId, }); 

			CustomConfig(type);

        }
    }
}
