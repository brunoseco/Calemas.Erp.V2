using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class PaisRepository : PaisRepositoryBase
    {
        public PaisRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Pais> GetByFilters(PaisFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Pais GetById(PaisFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Pais GetByModel(Pais model)
        {
            return this.GetAll().Where(_ => _.PaisId == model.PaisId).SingleOrDefault();
        }

    }
}
