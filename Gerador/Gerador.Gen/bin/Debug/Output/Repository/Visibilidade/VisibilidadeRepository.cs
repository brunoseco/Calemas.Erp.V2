using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class VisibilidadeRepository : VisibilidadeRepositoryBase
    {
        public VisibilidadeRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Visibilidade> GetByFilters(VisibilidadeFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Visibilidade GetById(VisibilidadeFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Visibilidade GetByModel(Visibilidade model)
        {
            return this.GetAll().Where(_ => _.VisibilidadeId == model.VisibilidadeId).SingleOrDefault();
        }

    }
}
