using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Core.Domain.Entities;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework.Mappings
{
    public class TimeCardRegisterMap : MappingBase<TimeCardRegister>
    {
        protected override void BeforeConfigure(EntityTypeBuilder<TimeCardRegister> builder)
        {
			builder.ToTable("AlocacaoColaborador");
            builder.Property(t => t.StartDate)
                .IsRequired()
                .HasColumnName("DataHoraInicio");
            builder
                .Property(t => t.EndDate)
                .IsRequired(false)
                .HasColumnName("DataHoraFim");
            builder.HasOne(t => t.Project)
                .WithMany(t => t.TimeCardRegisters)
                .HasForeignKey("IDProjeto");
            builder.HasOne(t => t.User)
                .WithMany(t => t.TimeCardRegisters)
                .HasForeignKey("IDColaborador");
        }

        protected override void ConfigureKey(EntityTypeBuilder<TimeCardRegister> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .HasColumnName("IDAlocacaoColaborador");
        }
    }
}