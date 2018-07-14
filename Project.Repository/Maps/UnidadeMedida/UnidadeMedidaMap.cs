using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CalemasERP.Core.Data.Model;

namespace CalemasERP.Core.Data.Maps
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
