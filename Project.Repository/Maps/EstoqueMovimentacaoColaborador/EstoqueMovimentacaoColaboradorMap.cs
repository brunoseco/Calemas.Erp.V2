using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CalemasERP.Core.Data.Model;

namespace CalemasERP.Core.Data.Maps
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
