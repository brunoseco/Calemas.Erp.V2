using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class StatusNegocioRepository : StatusNegocioRepositoryBase
    {
        public StatusNegocioRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<StatusNegocio> GetByFilters(StatusNegocioFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public StatusNegocio GetById(StatusNegocioFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public StatusNegocio GetByModel(StatusNegocio model)
        {
            return this.GetAll().Where(_ => _.StatusNegocioId == model.StatusNegocioId).SingleOrDefault();
        }

    }
}
