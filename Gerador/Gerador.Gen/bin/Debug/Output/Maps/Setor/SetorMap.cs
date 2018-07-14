using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class SetorMap : SetorMapBase
    {
        public SetorMap(EntityTypeBuilder<Setor> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Setor> type)
        {

        }
    }
}
