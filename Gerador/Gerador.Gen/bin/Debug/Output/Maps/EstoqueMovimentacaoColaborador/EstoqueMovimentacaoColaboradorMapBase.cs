using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Data.Maps
{
    public abstract class EstoqueMovimentacaoColaboradorMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<EstoqueMovimentacaoColaborador> type);

        public EstoqueMovimentacaoColaboradorMapBase(EntityTypeBuilder<EstoqueMovimentacaoColaborador> type)
        {
            type.ToTable("EstoqueMovimentacaoColaborador");

            type.Property(t => t.EstoqueMovimentacaoColaboradorId).HasColumnName("Id");


            type.Property(t => t.ColaboradorId).HasColumnName("ColaboradorId");
            type.Property(t => t.EstoqueMovimentacaoId).HasColumnName("EstoqueMovimentacaoId");
            type.Property(t => t.Entrada).HasColumnName("Entrada");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(500)");
            type.Property(t => t.Quantidade).HasColumnName("Quantidade");


            type.HasKey(d => new { d.EstoqueMovimentacaoColaboradorId, }); 

			CustomConfig(type);

        }
    }
}
