using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class VisibilidadeMap : VisibilidadeMapBase
    {
        public VisibilidadeMap(EntityTypeBuilder<Visibilidade> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Visibilidade> type)
        {

        }
    }
}
