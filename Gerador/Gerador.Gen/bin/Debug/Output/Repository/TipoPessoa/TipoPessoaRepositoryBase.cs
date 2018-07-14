using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class TipoPessoaRepositoryBase : Repository<TipoPessoa>
    {
        public TipoPessoaRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(TipoPessoaFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.TipoPessoaId, Name = _.Nome });
        }

        protected IQueryable<TipoPessoa> SimpleFilters(TipoPessoaFilter filters, IQueryable<TipoPessoa> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.TipoPessoaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.TipoPessoaId == filters.TipoPessoaId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
