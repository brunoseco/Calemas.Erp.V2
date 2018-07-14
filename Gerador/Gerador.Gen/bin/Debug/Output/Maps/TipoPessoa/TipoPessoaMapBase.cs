using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class TipoPessoaMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<TipoPessoa> type);

        public TipoPessoaMapBase(EntityTypeBuilder<TipoPessoa> type)
        {
            type.ToTable("TipoPessoa");

            type.Property(t => t.TipoPessoaId).HasColumnName("Id");


            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(150)");


            type.HasKey(d => new { d.TipoPessoaId, }); 

			CustomConfig(type);

        }
    }
}
