using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class EmpresaRepositoryBase : Repository<Empresa>
    {
        public EmpresaRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(EmpresaFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.EmpresaId, Name = _.Nome });
        }

        protected IQueryable<Empresa> SimpleFilters(EmpresaFilter filters, IQueryable<Empresa> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.EmpresaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EmpresaId == filters.EmpresaId);
			}
            if (filters.AssinaturaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.AssinaturaId != null && _.AssinaturaId.Value == filters.AssinaturaId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.ProprietarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ProprietarioId != null && _.ProprietarioId.Value == filters.ProprietarioId);
			}
            if (filters.DataCriacaoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataCriacao >= filters.DataCriacaoStart );
			}
            if (filters.DataCriacaoEnd.IsSent()) 
			{ 
				filters.DataCriacaoEnd = filters.DataCriacaoEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataCriacao <= filters.DataCriacaoEnd);
			}

            if (filters.DataAtualizacaoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataAtualizacao != null && _.DataAtualizacao.Value >= filters.DataAtualizacaoStart.Value);
			}
            if (filters.DataAtualizacaoEnd.IsSent()) 
			{ 
				filters.DataAtualizacaoEnd = filters.DataAtualizacaoEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataAtualizacao != null &&  _.DataAtualizacao.Value <= filters.DataAtualizacaoEnd);
			}

            if (filters.VisibilidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.VisibilidadeId == filters.VisibilidadeId);
			}


            return queryFilter;
        }
        
    }
}
