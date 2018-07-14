using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class NegocioRepositoryBase : Repository<Negocio>
    {
        public NegocioRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(NegocioFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.NegocioId, Name = _.Titulo });
        }

        protected IQueryable<Negocio> SimpleFilters(NegocioFilter filters, IQueryable<Negocio> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.NegocioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.NegocioId == filters.NegocioId);
			}
            if (filters.Titulo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Titulo.Contains(filters.Titulo));
			}
            if (filters.EmpresaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EmpresaId == filters.EmpresaId);
			}
            if (filters.AssinaturaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.AssinaturaId == filters.AssinaturaId);
			}
            if (filters.UsuarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.UsuarioId != null && _.UsuarioId.Value == filters.UsuarioId);
			}
            if (filters.ProprietarioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.ProprietarioId != null && _.ProprietarioId.Value == filters.ProprietarioId);
			}
            if (filters.Valor.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Valor != null && _.Valor.Value == filters.Valor);
			}
            if (filters.FunilId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.FunilId != null && _.FunilId.Value == filters.FunilId);
			}
            if (filters.EtapaAtual.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.EtapaAtual != null && _.EtapaAtual.Value == filters.EtapaAtual);
			}
            if (filters.Probabilidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Probabilidade != null && _.Probabilidade.Value == filters.Probabilidade);
			}
            if (filters.DataProximaAtividadeStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataProximaAtividade != null && _.DataProximaAtividade.Value >= filters.DataProximaAtividadeStart.Value);
			}
            if (filters.DataProximaAtividadeEnd.IsSent()) 
			{ 
				filters.DataProximaAtividadeEnd = filters.DataProximaAtividadeEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataProximaAtividade != null &&  _.DataProximaAtividade.Value <= filters.DataProximaAtividadeEnd);
			}

            if (filters.DataUltimaAtividadeStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataUltimaAtividade != null && _.DataUltimaAtividade.Value >= filters.DataUltimaAtividadeStart.Value);
			}
            if (filters.DataUltimaAtividadeEnd.IsSent()) 
			{ 
				filters.DataUltimaAtividadeEnd = filters.DataUltimaAtividadeEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataUltimaAtividade != null &&  _.DataUltimaAtividade.Value <= filters.DataUltimaAtividadeEnd);
			}

            if (filters.DataGanhoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataGanho != null && _.DataGanho.Value >= filters.DataGanhoStart.Value);
			}
            if (filters.DataGanhoEnd.IsSent()) 
			{ 
				filters.DataGanhoEnd = filters.DataGanhoEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataGanho != null &&  _.DataGanho.Value <= filters.DataGanhoEnd);
			}

            if (filters.DataPerdaStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataPerda != null && _.DataPerda.Value >= filters.DataPerdaStart.Value);
			}
            if (filters.DataPerdaEnd.IsSent()) 
			{ 
				filters.DataPerdaEnd = filters.DataPerdaEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataPerda != null &&  _.DataPerda.Value <= filters.DataPerdaEnd);
			}

            if (filters.DataFechamentoNegocioStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataFechamentoNegocio != null && _.DataFechamentoNegocio.Value >= filters.DataFechamentoNegocioStart.Value);
			}
            if (filters.DataFechamentoNegocioEnd.IsSent()) 
			{ 
				filters.DataFechamentoNegocioEnd = filters.DataFechamentoNegocioEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataFechamentoNegocio != null &&  _.DataFechamentoNegocio.Value <= filters.DataFechamentoNegocioEnd);
			}

            if (filters.MotivoPerdaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.MotivoPerdaId != null && _.MotivoPerdaId.Value == filters.MotivoPerdaId);
			}
            if (filters.VisibilidadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.VisibilidadeId == filters.VisibilidadeId);
			}
            if (filters.DataFechamentoEsperadaStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataFechamentoEsperada != null && _.DataFechamentoEsperada.Value >= filters.DataFechamentoEsperadaStart.Value);
			}
            if (filters.DataFechamentoEsperadaEnd.IsSent()) 
			{ 
				filters.DataFechamentoEsperadaEnd = filters.DataFechamentoEsperadaEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataFechamentoEsperada != null &&  _.DataFechamentoEsperada.Value <= filters.DataFechamentoEsperadaEnd);
			}

            if (filters.StatusNegocioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.StatusNegocioId == filters.StatusNegocioId);
			}
            if (filters.DataCriacaoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataCriacao >= filters.DataCriacaoStart );
			}
            if (filters.DataCriacaoEnd.IsSent()) 
			{ 
				filters.DataCriacaoEnd = filters.DataCriacaoEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataCriacao <= filters.DataCriacaoEnd);
			}

            if (filters.DataAtualizacaoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.DataAtualizacao != null && _.DataAtualizacao.Value >= filters.DataAtualizacaoStart.Value);
			}
            if (filters.DataAtualizacaoEnd.IsSent()) 
			{ 
				filters.DataAtualizacaoEnd = filters.DataAtualizacaoEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_ => _.DataAtualizacao != null &&  _.DataAtualizacao.Value <= filters.DataAtualizacaoEnd);
			}



            return queryFilter;
        }
        
    }
}
