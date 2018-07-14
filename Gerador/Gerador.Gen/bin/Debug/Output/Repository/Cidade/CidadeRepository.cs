using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class CidadeRepository : CidadeRepositoryBase
    {
        public CidadeRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Cidade> GetByFilters(CidadeFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Cidade GetById(CidadeFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Cidade GetByModel(Cidade model)
        {
            return this.GetAll().Where(_ => _.CidadeId == model.CidadeId).SingleOrDefault();
        }

    }
}
