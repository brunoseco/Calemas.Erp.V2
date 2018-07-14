using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class PessoaMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Pessoa> type);

        public PessoaMapBase(EntityTypeBuilder<Pessoa> type)
        {
            type.ToTable("Pessoa");

            type.Property(t => t.PessoaId).HasColumnName("Id");


            type.Property(t => t.AssinaturaId).HasColumnName("AssinaturaId");
            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(255)");
            type.Property(t => t.DataCriacao).HasColumnName("DataCriacao");
            type.Property(t => t.VisibilidadeId).HasColumnName("VisibilidadeId");


            type.HasKey(d => new { d.PessoaId, }); 

			CustomConfig(type);

        }
    }
}
