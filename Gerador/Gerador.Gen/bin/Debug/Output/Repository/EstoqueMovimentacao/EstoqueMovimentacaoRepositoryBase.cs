using Common.Orm;
using calemaserp.ui.Core.Filters;
using calemaserp.ui.Core.Data.Context;
using calemaserp.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace calemaserp.ui.Core.Data.Repository
{
    public class EstoqueMovimentacaoRepositoryBase : Repository<EstoqueMovimentacao>
    {
        public EstoqueMovimentacaoRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(EstoqueMovimentacaoFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.EstoqueMovimentacaoId, Name = _.Entrada });
        }

        protected IQueryable<EstoqueMovimentacao> SimpleFilters(EstoqueMovimentacaoFilter filters, IQueryable<EstoqueMovimentacao> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.EstoqueMovimentacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EstoqueMovimentacaoId == filters.EstoqueMovimentacaoId);
			}
            if (filters.EstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EstoqueId == filters.EstoqueId);
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
            if (filters.MotivoEstoqueMovimentacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.MotivoEstoqueMovimentacaoId != null && _.MotivoEstoqueMovimentacaoId.Value == filters.MotivoEstoqueMovimentacaoId);
			}
            if (filters.ResponsavelId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ResponsavelId == filters.ResponsavelId);
			}
            if (filters.UserCreateId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserCreateId == filters.UserCreateId);
			}
            if (filters.UserCreateDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserCreateDate >= filters.UserCreateDateStart );
			}
            if (filters.UserCreateDateEnd.IsSent()) 
			{ 
				filters.UserCreateDateEnd = filters.UserCreateDateEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.UserCreateDate <= filters.UserCreateDateEnd);
			}

            if (filters.UserAlterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserAlterId != null && _.UserAlterId.Value == filters.UserAlterId);
			}
            if (filters.UserAlterDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserAlterDate != null && _.UserAlterDate.Value >= filters.UserAlterDateStart.Value);
			}
            if (filters.UserAlterDateEnd.IsSent()) 
			{ 
				filters.UserAlterDateEnd = filters.UserAlterDateEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.UserAlterDate != null &&  _.UserAlterDate.Value <= filters.UserAlterDateEnd);
			}



            return queryFilter;
        }
        
    }
}
