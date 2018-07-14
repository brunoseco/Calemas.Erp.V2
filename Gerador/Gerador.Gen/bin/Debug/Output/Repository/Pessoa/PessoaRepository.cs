using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;

namespace superacrm.ui.Core.Data.Repository
{
    public class PessoaRepository : PessoaRepositoryBase
    {
        public PessoaRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<Pessoa> GetByFilters(PessoaFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public Pessoa GetById(PessoaFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public Pessoa GetByModel(Pessoa model)
        {
            return this.GetAll().Where(_ => _.PessoaId == model.PessoaId).SingleOrDefault();
        }

    }
}
