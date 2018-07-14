using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class ProdutoMap : ProdutoMapBase
    {
        public ProdutoMap(EntityTypeBuilder<Produto> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Produto> type)
        {

        }
    }
}
