using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class RegiaoMap : RegiaoMapBase
    {
        public RegiaoMap(EntityTypeBuilder<Regiao> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Regiao> type)
        {

        }
    }
}
