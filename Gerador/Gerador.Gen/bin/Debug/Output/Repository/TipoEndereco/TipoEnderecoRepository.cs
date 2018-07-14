using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class TipoEnderecoRepository : TipoEnderecoRepositoryBase
    {
        public TipoEnderecoRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<TipoEndereco> GetByFilters(TipoEnderecoFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public TipoEndereco GetById(TipoEnderecoFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public TipoEndereco GetByModel(TipoEndereco model)
        {
            return this.GetAll().Where(_ => _.TipoEnderecoId == model.TipoEnderecoId).SingleOrDefault();
        }

    }
}
