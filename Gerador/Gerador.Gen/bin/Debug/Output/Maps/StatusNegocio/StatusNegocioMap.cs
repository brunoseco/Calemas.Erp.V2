using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class StatusNegocioMap : StatusNegocioMapBase
    {
        public StatusNegocioMap(EntityTypeBuilder<StatusNegocio> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<StatusNegocio> type)
        {

        }
    }
}
