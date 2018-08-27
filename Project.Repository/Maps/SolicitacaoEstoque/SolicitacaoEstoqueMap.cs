using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CalemasERP.Core.Data.Model;

namespace CalemasERP.Core.Data.Maps
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
