using Common.Orm;
using calemaserp.ui.Core.Filters;
using calemaserp.ui.Core.Data.Context;
using calemaserp.ui.Core.Data.Model;
using System.Linq;

namespace calemaserp.ui.Core.Data.Repository
{
    public class EstoqueRepository : EstoqueRepositoryBase
    {
        public EstoqueRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Estoque> GetByFilters(EstoqueFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Estoque GetById(EstoqueFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Estoque GetByModel(Estoque model)
        {
            return this.GetAll().Where(_ => _.EstoqueId == model.EstoqueId).SingleOrDefault();
        }

    }
}
