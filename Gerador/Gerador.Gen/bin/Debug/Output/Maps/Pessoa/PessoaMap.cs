using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class PessoaMap : PessoaMapBase
    {
        public PessoaMap(EntityTypeBuilder<Pessoa> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Pessoa> type)
        {

        }
    }
}
