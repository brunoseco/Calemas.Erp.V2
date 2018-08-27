using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CalemasERP.Core.Data.Model;

namespace CalemasERP.Core.Data.Maps
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
