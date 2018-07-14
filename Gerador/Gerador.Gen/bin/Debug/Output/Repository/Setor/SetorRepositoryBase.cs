using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class SetorRepositoryBase : Repository<Setor>
    {
        public SetorRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(SetorFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.SetorId, Name = _.Nome });
        }

        protected IQueryable<Setor> SimpleFilters(SetorFilter filters, IQueryable<Setor> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.SetorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.SetorId == filters.SetorId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
