using Common.Orm;
using calemaserp.ui.Core.Filters;
using calemaserp.ui.Core.Data.Context;
using calemaserp.ui.Core.Data.Model;
using System.Linq;

namespace calemaserp.ui.Core.Data.Repository
{
    public class EstoqueMovimentacaoRepository : EstoqueMovimentacaoRepositoryBase
    {
        public EstoqueMovimentacaoRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<EstoqueMovimentacao> GetByFilters(EstoqueMovimentacaoFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public EstoqueMovimentacao GetById(EstoqueMovimentacaoFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public EstoqueMovimentacao GetByModel(EstoqueMovimentacao model)
        {
            return this.GetAll().Where(_ => _.EstoqueMovimentacaoId == model.EstoqueMovimentacaoId).SingleOrDefault();
        }

    }
}
