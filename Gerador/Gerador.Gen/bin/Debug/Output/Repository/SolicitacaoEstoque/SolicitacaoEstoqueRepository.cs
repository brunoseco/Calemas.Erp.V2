using Common.Orm;
using calemaserp.ui.Core.Filters;
using calemaserp.ui.Core.Data.Context;
using calemaserp.ui.Core.Data.Model;
using System.Linq;

namespace calemaserp.ui.Core.Data.Repository
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
