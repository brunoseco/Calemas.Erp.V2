using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class CidadeRepositoryBase : Repository<Cidade>
    {
        public CidadeRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(CidadeFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.CidadeId, Name = _.Nome });
        }

        protected IQueryable<Cidade> SimpleFilters(CidadeFilter filters, IQueryable<Cidade> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.CidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.CidadeId == filters.CidadeId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.UF.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UF.Contains(filters.UF));
			}


            return queryFilter;
        }
        
    }
}
