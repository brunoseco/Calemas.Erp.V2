using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Data.Maps
{
    public abstract class UnidadeMedidaMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<UnidadeMedida> type);

        public UnidadeMedidaMapBase(EntityTypeBuilder<UnidadeMedida> type)
        {
            type.ToTable("UnidadeMedida");

            type.Property(t => t.UnidadeMedidaId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(100)");


            type.HasKey(d => new { d.UnidadeMedidaId, }); 

			CustomConfig(type);

        }
    }
}
