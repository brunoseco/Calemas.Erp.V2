using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class AssinaturaRepositoryBase : Repository<Assinatura>
    {
        public AssinaturaRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(AssinaturaFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.AssinaturaId, Name = _.Nome });
        }

        protected IQueryable<Assinatura> SimpleFilters(AssinaturaFilter filters, IQueryable<Assinatura> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.AssinaturaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.AssinaturaId == filters.AssinaturaId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}
            if (filters.Empresa.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Empresa.Contains(filters.Empresa));
			}
            if (filters.SetorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.SetorId == filters.SetorId);
			}
            if (filters.Telefone.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Telefone.Contains(filters.Telefone));
			}
            if (filters.Senha.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Senha.Contains(filters.Senha));
			}
            if (filters.CpfCnpj.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.CpfCnpj.Contains(filters.CpfCnpj));
			}
            if (filters.Logradouro.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Logradouro.Contains(filters.Logradouro));
			}
            if (filters.Numero.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Numero.Contains(filters.Numero));
			}
            if (filters.Complemento.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Complemento.Contains(filters.Complemento));
			}
            if (filters.Bairro.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Bairro.Contains(filters.Bairro));
			}
            if (filters.CidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.CidadeId == filters.CidadeId);
			}
            if (filters.UF.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UF.Contains(filters.UF));
			}
            if (filters.PaisId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.PaisId == filters.PaisId);
			}


            return queryFilter;
        }
        
    }
}
