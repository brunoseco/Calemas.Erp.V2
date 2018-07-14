using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class TipoEmailMap : TipoEmailMapBase
    {
        public TipoEmailMap(EntityTypeBuilder<TipoEmail> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<TipoEmail> type)
        {

        }
    }
}
