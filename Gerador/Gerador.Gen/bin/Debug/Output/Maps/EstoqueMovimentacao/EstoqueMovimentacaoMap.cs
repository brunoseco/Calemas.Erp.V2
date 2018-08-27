using Microsoft.EntityFrameworkCore.Metadata.Builders;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Data.Maps
{
    public class EstoqueMovimentacaoMap : EstoqueMovimentacaoMapBase
    {
        public EstoqueMovimentacaoMap(EntityTypeBuilder<EstoqueMovimentacao> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<EstoqueMovimentacao> type)
        {

        }
    }
}
