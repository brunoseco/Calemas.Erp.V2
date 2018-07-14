using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class TipoTelefoneRepositoryBase : Repository<TipoTelefone>
    {
        public TipoTelefoneRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(TipoTelefoneFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.TipoTelefoneId, Name = _.Nome });
        }

        protected IQueryable<TipoTelefone> SimpleFilters(TipoTelefoneFilter filters, IQueryable<TipoTelefone> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.TipoTelefoneId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.TipoTelefoneId == filters.TipoTelefoneId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
