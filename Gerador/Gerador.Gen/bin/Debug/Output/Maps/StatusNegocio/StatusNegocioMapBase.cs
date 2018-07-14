using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class StatusNegocioMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<StatusNegocio> type);

        public StatusNegocioMapBase(EntityTypeBuilder<StatusNegocio> type)
        {
            type.ToTable("StatusNegocio");

            type.Property(t => t.StatusNegocioId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.AssinaturaId).HasColumnName("AssinaturaId");


            type.HasKey(d => new { d.StatusNegocioId, }); 

			CustomConfig(type);

        }
    }
}
