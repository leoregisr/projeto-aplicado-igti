using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Core.Domain.Entities;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework.Mappings
{
    public class UserMap : MappingBase<User>
    {
        protected override void BeforeConfigure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Colaborador");
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Nome");
            builder
                .Property(t => t.Email)
                .IsRequired()
                .HasColumnName("Email");
            builder
                .Property(t => t.Password)
                .IsRequired()
                .HasColumnName("Senha");
            builder
                .HasOne(t => t.Manager)
                .WithMany(t => t.Employees)
                .HasForeignKey("IDGestor");
            builder
                .HasOne(t => t.Role)
                .WithMany(t => t.Employees)
                .HasForeignKey("IDCargo");
        }

        protected override void ConfigureKey(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .HasColumnName("IDColaborador");
        }
    }
}