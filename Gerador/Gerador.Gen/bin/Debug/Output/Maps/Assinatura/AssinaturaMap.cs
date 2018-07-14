using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class AssinaturaMap : AssinaturaMapBase
    {
        public AssinaturaMap(EntityTypeBuilder<Assinatura> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Assinatura> type)
        {

        }
    }
}
