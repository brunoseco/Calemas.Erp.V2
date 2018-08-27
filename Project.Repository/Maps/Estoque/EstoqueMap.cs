using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CalemasERP.Core.Data.Model;

namespace CalemasERP.Core.Data.Maps
{
    public class EstoqueMap : EstoqueMapBase
    {
        public EstoqueMap(EntityTypeBuilder<Estoque> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Estoque> type)
        {

        }
    }
}
