using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class SetorMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Setor> type);

        public SetorMapBase(EntityTypeBuilder<Setor> type)
        {
            type.ToTable("Setor");

            type.Property(t => t.SetorId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");


            type.HasKey(d => new { d.SetorId, }); 

			CustomConfig(type);

        }
    }
}
