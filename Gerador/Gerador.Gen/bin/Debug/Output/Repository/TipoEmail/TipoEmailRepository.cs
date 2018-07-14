using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class TipoEmailRepository : TipoEmailRepositoryBase
    {
        public TipoEmailRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<TipoEmail> GetByFilters(TipoEmailFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public TipoEmail GetById(TipoEmailFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public TipoEmail GetByModel(TipoEmail model)
        {
            return this.GetAll().Where(_ => _.TipoEmailId == model.TipoEmailId).SingleOrDefault();
        }

    }
}
