using Common.Orm;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace CalemasERP.Core.Data.Repository
{
    public class MotivoEstoqueMovimentacaoRepositoryBase : Repository<MotivoEstoqueMovimentacao>
    {
        public MotivoEstoqueMovimentacaoRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(MotivoEstoqueMovimentacaoFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.MotivoEstoqueMovimentacaoId, Name = _.Nome });
        }

        protected IQueryable<MotivoEstoqueMovimentacao> SimpleFilters(MotivoEstoqueMovimentacaoFilter filters, IQueryable<MotivoEstoqueMovimentacao> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.MotivoEstoqueMovimentacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.MotivoEstoqueMovimentacaoId == filters.MotivoEstoqueMovimentacaoId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
