using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Core.Data.Model;

namespace Calemas.Erp.Core.Data.Maps
{
    public abstract class ChangeLogMapBase
    {
        protected abstract void CustomConfig(EntityTypeBuilder<ChangeLog> type);

        public ChangeLogMapBase(EntityTypeBuilder<ChangeLog> type)
        {
            type.ToTable("ChangeLog");

            type.Property(t => t.ChangeLogId).HasColumnName("Id");


            type.Property(t => t.Versao).HasColumnName("Versao").HasColumnType("varchar(50)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(max)");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.ChangeLogId, }); 

			CustomConfig(type);

        }
    }
}
