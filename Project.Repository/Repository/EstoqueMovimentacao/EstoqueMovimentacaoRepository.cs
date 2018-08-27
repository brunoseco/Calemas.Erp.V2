using Common.Orm;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Model;
using System.Linq;

namespace CalemasERP.Core.Data.Repository
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
