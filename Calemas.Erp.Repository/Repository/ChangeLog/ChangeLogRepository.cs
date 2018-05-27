using Common.Orm;
using Calemas.Erp.Core.Filters;
using Calemas.Erp.Core.Data.Context;
using Calemas.Erp.Core.Data.Model;
using System.Linq;

namespace Calemas.Erp.Core.Data.Repository
{
    public class ChangeLogRepository : ChangeLogRepositoryBase
    {
        public ChangeLogRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<ChangeLog> GetByFilters(ChangeLogFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public ChangeLog GetById(ChangeLogFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public ChangeLog GetByModel(ChangeLog model)
        {
            return this.GetAll().Where(_ => _.ChangeLogId == model.ChangeLogId).SingleOrDefault();
        }

    }
}
