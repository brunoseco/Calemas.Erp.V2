using Microsoft.EntityFrameworkCore.Metadata.Builders;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Data.Maps
{
    public class MotivoEstoqueMovimentacaoMap : MotivoEstoqueMovimentacaoMapBase
    {
        public MotivoEstoqueMovimentacaoMap(EntityTypeBuilder<MotivoEstoqueMovimentacao> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<MotivoEstoqueMovimentacao> type)
        {

        }
    }
}
