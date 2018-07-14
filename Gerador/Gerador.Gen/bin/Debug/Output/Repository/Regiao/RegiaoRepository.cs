using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class RegiaoRepository : RegiaoRepositoryBase
    {
        public RegiaoRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Regiao> GetByFilters(RegiaoFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Regiao GetById(RegiaoFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Regiao GetByModel(Regiao model)
        {
            return this.GetAll().Where(_ => _.RegiaoId == model.RegiaoId).SingleOrDefault();
        }

    }
}
