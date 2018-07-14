using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class TipoTelefoneRepository : TipoTelefoneRepositoryBase
    {
        public TipoTelefoneRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<TipoTelefone> GetByFilters(TipoTelefoneFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public TipoTelefone GetById(TipoTelefoneFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public TipoTelefone GetByModel(TipoTelefone model)
        {
            return this.GetAll().Where(_ => _.TipoTelefoneId == model.TipoTelefoneId).SingleOrDefault();
        }

    }
}
