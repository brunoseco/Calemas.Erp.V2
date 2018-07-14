using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class PaisRepositoryBase : Repository<Pais>
    {
        public PaisRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(PaisFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.PaisId, Name = _.Nome });
        }

        protected IQueryable<Pais> SimpleFilters(PaisFilter filters, IQueryable<Pais> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.PaisId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.PaisId == filters.PaisId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
