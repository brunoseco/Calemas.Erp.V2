using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class PessoaRepositoryBase : Repository<Pessoa>
    {
        public PessoaRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(PessoaFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.PessoaId, Name = _.Nome });
        }

        protected IQueryable<Pessoa> SimpleFilters(PessoaFilter filters, IQueryable<Pessoa> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.PessoaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.PessoaId == filters.PessoaId);
			}
            if (filters.AssinaturaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.AssinaturaId == filters.AssinaturaId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
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

            if (filters.VisibilidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.VisibilidadeId == filters.VisibilidadeId);
			}


            return queryFilter;
        }
        
    }
}
