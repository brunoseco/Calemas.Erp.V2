using Common.Orm;
using calemaserp.ui.Core.Filters;
using calemaserp.ui.Core.Data.Context;
using calemaserp.ui.Core.Data.Model;
using System.Linq;

namespace calemaserp.ui.Core.Data.Repository
{
    public class UnidadeMedidaRepository : UnidadeMedidaRepositoryBase
    {
        public UnidadeMedidaRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<UnidadeMedida> GetByFilters(UnidadeMedidaFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public UnidadeMedida GetById(UnidadeMedidaFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public UnidadeMedida GetByModel(UnidadeMedida model)
        {
            return this.GetAll().Where(_ => _.UnidadeMedidaId == model.UnidadeMedidaId).SingleOrDefault();
        }

    }
}
