using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class CidadeMap : CidadeMapBase
    {
        public CidadeMap(EntityTypeBuilder<Cidade> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Cidade> type)
        {

        }
    }
}
