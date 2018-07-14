using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class TipoTelefoneMap : TipoTelefoneMapBase
    {
        public TipoTelefoneMap(EntityTypeBuilder<TipoTelefone> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<TipoTelefone> type)
        {

        }
    }
}
