using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class TipoEnderecoMap : TipoEnderecoMapBase
    {
        public TipoEnderecoMap(EntityTypeBuilder<TipoEndereco> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<TipoEndereco> type)
        {

        }
    }
}
