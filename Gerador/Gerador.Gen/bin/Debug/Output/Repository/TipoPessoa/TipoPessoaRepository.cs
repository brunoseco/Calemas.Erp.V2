using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class TipoPessoaRepository : TipoPessoaRepositoryBase
    {
        public TipoPessoaRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<TipoPessoa> GetByFilters(TipoPessoaFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public TipoPessoa GetById(TipoPessoaFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public TipoPessoa GetByModel(TipoPessoa model)
        {
            return this.GetAll().Where(_ => _.TipoPessoaId == model.TipoPessoaId).SingleOrDefault();
        }

    }
}
