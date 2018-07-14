using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class VisibilidadeRepositoryBase : Repository<Visibilidade>
    {
        public VisibilidadeRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(VisibilidadeFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.VisibilidadeId, Name = _.Nome });
        }

        protected IQueryable<Visibilidade> SimpleFilters(VisibilidadeFilter filters, IQueryable<Visibilidade> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.VisibilidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.VisibilidadeId == filters.VisibilidadeId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
