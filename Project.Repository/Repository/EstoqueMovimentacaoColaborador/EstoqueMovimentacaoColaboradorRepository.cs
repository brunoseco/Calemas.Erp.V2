using Common.Orm;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Model;
using System.Linq;

namespace CalemasERP.Core.Data.Repository
{
    public class EstoqueMovimentacaoColaboradorRepository : EstoqueMovimentacaoColaboradorRepositoryBase
    {
        public EstoqueMovimentacaoColaboradorRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<EstoqueMovimentacaoColaborador> GetByFilters(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public EstoqueMovimentacaoColaborador GetById(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public EstoqueMovimentacaoColaborador GetByModel(EstoqueMovimentacaoColaborador model)
        {
            return this.GetAll().Where(_ => _.EstoqueMovimentacaoColaboradorId == model.EstoqueMovimentacaoColaboradorId).SingleOrDefault();
        }

    }
}
