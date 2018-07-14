using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class RegiaoRepositoryBase : Repository<Regiao>
    {
        public RegiaoRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(RegiaoFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.RegiaoId, Name = _.Nome });
        }

        protected IQueryable<Regiao> SimpleFilters(RegiaoFilter filters, IQueryable<Regiao> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.RegiaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.RegiaoId == filters.RegiaoId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
