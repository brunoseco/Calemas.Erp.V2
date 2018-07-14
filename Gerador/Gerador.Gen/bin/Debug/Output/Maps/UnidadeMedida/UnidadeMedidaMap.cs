using Microsoft.EntityFrameworkCore.Metadata.Builders;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Data.Maps
{
    public class UnidadeMedidaMap : UnidadeMedidaMapBase
    {
        public UnidadeMedidaMap(EntityTypeBuilder<UnidadeMedida> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<UnidadeMedida> type)
        {

        }
    }
}
