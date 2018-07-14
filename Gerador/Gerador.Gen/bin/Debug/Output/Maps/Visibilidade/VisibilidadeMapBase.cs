using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class VisibilidadeMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Visibilidade> type);

        public VisibilidadeMapBase(EntityTypeBuilder<Visibilidade> type)
        {
            type.ToTable("Visibilidade");

            type.Property(t => t.VisibilidadeId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");


            type.HasKey(d => new { d.VisibilidadeId, }); 

			CustomConfig(type);

        }
    }
}
