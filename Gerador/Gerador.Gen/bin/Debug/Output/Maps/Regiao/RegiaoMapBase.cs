using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class RegiaoMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Regiao> type);

        public RegiaoMapBase(EntityTypeBuilder<Regiao> type)
        {
            type.ToTable("Regiao");

            type.Property(t => t.RegiaoId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");


            type.HasKey(d => new { d.RegiaoId, }); 

			CustomConfig(type);

        }
    }
}
