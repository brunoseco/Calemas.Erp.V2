using Microsoft.EntityFrameworkCore.Metadata.Builders;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Data.Maps
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
