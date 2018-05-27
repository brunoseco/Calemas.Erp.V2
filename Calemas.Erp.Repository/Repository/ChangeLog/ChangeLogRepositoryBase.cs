using Common.Orm;
using Calemas.Erp.Core.Filters;
using Calemas.Erp.Core.Data.Context;
using Calemas.Erp.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace Calemas.Erp.Core.Data.Repository
{
    public class ChangeLogRepositoryBase : Repository<ChangeLog>
    {
        public ChangeLogRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(ChangeLogFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.ChangeLogId, Name = _.Versao });
        }

        protected IQueryable<ChangeLog> SimpleFilters(ChangeLogFilter filters, IQueryable<ChangeLog> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.ChangeLogId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ChangeLogId == filters.ChangeLogId);
			}
            if (filters.Versao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Versao.Contains(filters.Versao));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Descricao.Contains(filters.Descricao));
			}
            if (filters.UserCreateId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserCreateId == filters.UserCreateId);
			}
            if (filters.UserCreateDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserCreateDate >= filters.UserCreateDateStart );
			}
            if (filters.UserCreateDateEnd.IsSent()) 
			{ 
				filters.UserCreateDateEnd = filters.UserCreateDateEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.UserCreateDate <= filters.UserCreateDateEnd);
			}

            if (filters.UserAlterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserAlterId != null && _.UserAlterId.Value == filters.UserAlterId);
			}
            if (filters.UserAlterDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UserAlterDate != null && _.UserAlterDate.Value >= filters.UserAlterDateStart.Value);
			}
            if (filters.UserAlterDateEnd.IsSent()) 
			{ 
				filters.UserAlterDateEnd = filters.UserAlterDateEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.UserAlterDate != null &&  _.UserAlterDate.Value <= filters.UserAlterDateEnd);
			}



            return queryFilter;
        }
        
    }
}
