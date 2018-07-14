using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class SetorRepository : SetorRepositoryBase
    {
        public SetorRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Setor> GetByFilters(SetorFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Setor GetById(SetorFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Setor GetByModel(Setor model)
        {
            return this.GetAll().Where(_ => _.SetorId == model.SetorId).SingleOrDefault();
        }

    }
}
