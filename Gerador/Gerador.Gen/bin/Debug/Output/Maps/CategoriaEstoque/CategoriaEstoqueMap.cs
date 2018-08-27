using Microsoft.EntityFrameworkCore.Metadata.Builders;
using calemaserp.ui.Core.Data.Model;

namespace calemaserp.ui.Core.Data.Maps
{
    public class CategoriaEstoqueMap : CategoriaEstoqueMapBase
    {
        public CategoriaEstoqueMap(EntityTypeBuilder<CategoriaEstoque> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<CategoriaEstoque> type)
        {

        }
    }
}
