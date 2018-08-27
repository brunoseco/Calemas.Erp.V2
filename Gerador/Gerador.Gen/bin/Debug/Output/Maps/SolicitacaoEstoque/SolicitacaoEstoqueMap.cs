using Microsoft.EntityFrameworkCore.Metadata.Builders;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Data.Maps
{
    public class SolicitacaoEstoqueMap : SolicitacaoEstoqueMapBase
    {
        public SolicitacaoEstoqueMap(EntityTypeBuilder<SolicitacaoEstoque> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<SolicitacaoEstoque> type)
        {

        }
    }
}
