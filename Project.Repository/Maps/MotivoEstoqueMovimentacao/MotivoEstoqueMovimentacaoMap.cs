using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CalemasERP.Core.Data.Model;

namespace CalemasERP.Core.Data.Maps
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
