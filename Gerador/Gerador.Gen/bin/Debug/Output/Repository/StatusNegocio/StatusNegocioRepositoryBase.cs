using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class StatusNegocioRepositoryBase : Repository<StatusNegocio>
    {
        public StatusNegocioRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(StatusNegocioFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.StatusNegocioId, Name = _.Nome });
        }

        protected IQueryable<StatusNegocio> SimpleFilters(StatusNegocioFilter filters, IQueryable<StatusNegocio> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.StatusNegocioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.StatusNegocioId == filters.StatusNegocioId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.AssinaturaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.AssinaturaId != null && _.AssinaturaId.Value == filters.AssinaturaId);
			}


            return queryFilter;
        }
        
    }
}
