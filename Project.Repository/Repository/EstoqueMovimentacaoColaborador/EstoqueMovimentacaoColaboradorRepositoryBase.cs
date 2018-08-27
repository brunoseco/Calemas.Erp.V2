using Common.Orm;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace CalemasERP.Core.Data.Repository
{
    public class EstoqueMovimentacaoColaboradorRepositoryBase : Repository<EstoqueMovimentacaoColaborador>
    {
        public EstoqueMovimentacaoColaboradorRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(EstoqueMovimentacaoColaboradorFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.EstoqueMovimentacaoColaboradorId, Name = _.Entrada });
        }

        protected IQueryable<EstoqueMovimentacaoColaborador> SimpleFilters(EstoqueMovimentacaoColaboradorFilter filters, IQueryable<EstoqueMovimentacaoColaborador> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.EstoqueMovimentacaoColaboradorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EstoqueMovimentacaoColaboradorId == filters.EstoqueMovimentacaoColaboradorId);
			}
            if (filters.ColaboradorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ColaboradorId == filters.ColaboradorId);
			}
            if (filters.EstoqueMovimentacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EstoqueMovimentacaoId == filters.EstoqueMovimentacaoId);
			}
            if (filters.Entrada.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Entrada == filters.Entrada);
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Descricao.Contains(filters.Descricao));
			}
            if (filters.Quantidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Quantidade == filters.Quantidade);
			}


            return queryFilter;
        }
        
    }
}
