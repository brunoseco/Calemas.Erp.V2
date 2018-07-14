using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class NegocioRepository : NegocioRepositoryBase
    {
        public NegocioRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Negocio> GetByFilters(NegocioFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Negocio GetById(NegocioFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Negocio GetByModel(Negocio model)
        {
            return this.GetAll().Where(_ => _.NegocioId == model.NegocioId).SingleOrDefault();
        }

    }
}
