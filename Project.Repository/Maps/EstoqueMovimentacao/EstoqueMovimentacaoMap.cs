using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CalemasERP.Core.Data.Model;

namespace CalemasERP.Core.Data.Maps
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
