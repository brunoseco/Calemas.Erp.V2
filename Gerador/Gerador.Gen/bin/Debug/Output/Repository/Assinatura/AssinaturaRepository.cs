using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class AssinaturaRepository : AssinaturaRepositoryBase
    {
        public AssinaturaRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Assinatura> GetByFilters(AssinaturaFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Assinatura GetById(AssinaturaFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Assinatura GetByModel(Assinatura model)
        {
            return this.GetAll().Where(_ => _.AssinaturaId == model.AssinaturaId).SingleOrDefault();
        }

    }
}
