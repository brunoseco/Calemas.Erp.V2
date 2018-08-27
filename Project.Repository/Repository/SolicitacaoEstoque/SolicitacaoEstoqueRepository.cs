using Common.Orm;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Model;
using System.Linq;

namespace CalemasERP.Core.Data.Repository
{
    public class SolicitacaoEstoqueRepository : SolicitacaoEstoqueRepositoryBase
    {
        public SolicitacaoEstoqueRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<SolicitacaoEstoque> GetByFilters(SolicitacaoEstoqueFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public SolicitacaoEstoque GetById(SolicitacaoEstoqueFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public SolicitacaoEstoque GetByModel(SolicitacaoEstoque model)
        {
            return this.GetAll().Where(_ => _.SolicitacaoEstoqueId == model.SolicitacaoEstoqueId).SingleOrDefault();
        }

    }
}
