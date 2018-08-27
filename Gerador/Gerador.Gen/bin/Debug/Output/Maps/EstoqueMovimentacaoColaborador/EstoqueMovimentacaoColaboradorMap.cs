using Microsoft.EntityFrameworkCore.Metadata.Builders;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Data.Maps
{
    public class EstoqueMovimentacaoColaboradorMap : EstoqueMovimentacaoColaboradorMapBase
    {
        public EstoqueMovimentacaoColaboradorMap(EntityTypeBuilder<EstoqueMovimentacaoColaborador> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<EstoqueMovimentacaoColaborador> type)
        {

        }
    }
}
