using Common.Orm;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Model;
using System.Linq;

namespace CalemasERP.Core.Data.Repository
{
    public class MotivoEstoqueMovimentacaoRepository : MotivoEstoqueMovimentacaoRepositoryBase
    {
        public MotivoEstoqueMovimentacaoRepository(DbContextCore ctx) : base(ctx)
        {

        }

        public IQueryable<MotivoEstoqueMovimentacao> GetByFilters(MotivoEstoqueMovimentacaoFilter filters)
        {
            var querybase = this.GetAll();

            var queryFilter = this.SimpleFilters(filters, querybase);

            return queryFilter;
        }

        public MotivoEstoqueMovimentacao GetById(MotivoEstoqueMovimentacaoFilter filters)
        {
            var querybase = this.GetByFilters(filters);
            return querybase.SingleOrDefault();
        }

		public MotivoEstoqueMovimentacao GetByModel(MotivoEstoqueMovimentacao model)
        {
            return this.GetAll().Where(_ => _.MotivoEstoqueMovimentacaoId == model.MotivoEstoqueMovimentacaoId).SingleOrDefault();
        }

    }
}
