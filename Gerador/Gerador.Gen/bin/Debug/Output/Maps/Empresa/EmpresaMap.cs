using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class EmpresaMap : EmpresaMapBase
    {
        public EmpresaMap(EntityTypeBuilder<Empresa> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Empresa> type)
        {

        }
    }
}
