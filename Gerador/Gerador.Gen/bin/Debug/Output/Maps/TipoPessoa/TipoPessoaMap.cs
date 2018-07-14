using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public class TipoPessoaMap : TipoPessoaMapBase
    {
        public TipoPessoaMap(EntityTypeBuilder<TipoPessoa> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<TipoPessoa> type)
        {

        }
    }
}
