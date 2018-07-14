using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class NegocioMap : NegocioMapBase
    {
        public NegocioMap(EntityTypeBuilder<Negocio> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Negocio> type)
        {

        }
    }
}
