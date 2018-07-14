using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class PaisMap : PaisMapBase
    {
        public PaisMap(EntityTypeBuilder<Pais> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Pais> type)
        {

        }
    }
}
