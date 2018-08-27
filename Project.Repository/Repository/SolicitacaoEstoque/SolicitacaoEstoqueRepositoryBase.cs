using Common.Orm;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Context;
using CalemasERP.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace CalemasERP.Core.Data.Repository
{
    public class SolicitacaoEstoqueRepositoryBase : Repository<SolicitacaoEstoque>
    {
        public SolicitacaoEstoqueRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(SolicitacaoEstoqueFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.SolicitacaoEstoqueId, Name = _.Descricao });
        }

        protected IQueryable<SolicitacaoEstoque> SimpleFilters(SolicitacaoEstoqueFilter filters, IQueryable<SolicitacaoEstoque> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.SolicitacaoEstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.SolicitacaoEstoqueId == filters.SolicitacaoEstoqueId);
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Descricao.Contains(filters.Descricao));
			}
            if (filters.SolicitanteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.SolicitanteId == filters.SolicitanteId);
			}
            if (filters.DataSolicitacaoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataSolicitacao >= filters.DataSolicitacaoStart );
			}
            if (filters.DataSolicitacaoEnd.IsSent()) 
			{ 
				filters.DataSolicitacaoEnd = filters.DataSolicitacaoEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataSolicitacao <= filters.DataSolicitacaoEnd);
			}

            if (filters.DataPrevistaStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataPrevista >= filters.DataPrevistaStart );
			}
            if (filters.DataPrevistaEnd.IsSent()) 
			{ 
				filters.DataPrevistaEnd = filters.DataPrevistaEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataPrevista <= filters.DataPrevistaEnd);
			}

            if (filters.StatusSolicitacaoEstoqueMovimentacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.StatusSolicitacaoEstoqueMovimentacaoId == filters.StatusSolicitacaoEstoqueMovimentacaoId);
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
