using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Core.Data.Model;

namespace Calemas.Erp.Core.Data.Maps
{
    public class ChangeLogMap : ChangeLogMapBase
    {
        public ChangeLogMap(EntityTypeBuilder<ChangeLog> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<ChangeLog> type)
        {

        }
    }
}
