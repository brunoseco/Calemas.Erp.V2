using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class PaisMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Pais> type);

        public PaisMapBase(EntityTypeBuilder<Pais> type)
        {
            type.ToTable("Pais");

            type.Property(t => t.PaisId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");


            type.HasKey(d => new { d.PaisId, }); 

			CustomConfig(type);

        }
    }
}
