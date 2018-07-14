using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using superacrm.ui.Core.Data.Model;

namespace superacrm.ui.Core.Data.Maps
{
    public abstract class NegocioMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Negocio> type);

        public NegocioMapBase(EntityTypeBuilder<Negocio> type)
        {
            type.ToTable("Negocio");

            type.Property(t => t.NegocioId).HasColumnName("Id");


            type.Property(t => t.Titulo).HasColumnName("Titulo").HasColumnType("varchar(255)");
            type.Property(t => t.EmpresaId).HasColumnName("EmpresaId");
            type.Property(t => t.AssinaturaId).HasColumnName("AssinaturaId");
            type.Property(t => t.UsuarioId).HasColumnName("UsuarioId");
            type.Property(t => t.ProprietarioId).HasColumnName("ProprietarioId");
            type.Property(t => t.Valor).HasColumnName("Valor");
            type.Property(t => t.FunilId).HasColumnName("FunilId");
            type.Property(t => t.EtapaAtual).HasColumnName("EtapaAtual");
            type.Property(t => t.Probabilidade).HasColumnName("Probabilidade");
            type.Property(t => t.DataProximaAtividade).HasColumnName("DataProximaAtividade");
            type.Property(t => t.DataUltimaAtividade).HasColumnName("DataUltimaAtividade");
            type.Property(t => t.DataGanho).HasColumnName("DataGanho");
            type.Property(t => t.DataPerda).HasColumnName("DataPerda");
            type.Property(t => t.DataFechamentoNegocio).HasColumnName("DataFechamentoNegocio");
            type.Property(t => t.MotivoPerdaId).HasColumnName("MotivoPerdaId");
            type.Property(t => t.VisibilidadeId).HasColumnName("VisibilidadeId");
            type.Property(t => t.DataFechamentoEsperada).HasColumnName("DataFechamentoEsperada");
            type.Property(t => t.StatusNegocioId).HasColumnName("StatusNegocioId");
            type.Property(t => t.DataCriacao).HasColumnName("DataCriacao");
            type.Property(t => t.DataAtualizacao).HasColumnName("DataAtualizacao");


            type.HasKey(d => new { d.NegocioId, }); 

			CustomConfig(type);

        }
    }
}
