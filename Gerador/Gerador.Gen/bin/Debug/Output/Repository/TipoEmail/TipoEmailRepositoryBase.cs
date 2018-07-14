using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class TipoEmailRepositoryBase : Repository<TipoEmail>
    {
        public TipoEmailRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(TipoEmailFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.TipoEmailId, Name = _.Nome });
        }

        protected IQueryable<TipoEmail> SimpleFilters(TipoEmailFilter filters, IQueryable<TipoEmail> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.TipoEmailId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.TipoEmailId == filters.TipoEmailId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
