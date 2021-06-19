using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Core.Domain.Entities;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework.Mappings
{
    public class RoleMap : MappingBase<Role>
    {
        protected override void BeforeConfigure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Cargo");
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Nome");
            builder
                .Property(t => t.Wage)
                .IsRequired()
                .HasColumnName("Salario");
        }

        protected override void ConfigureKey(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .HasColumnName("IDCargo");
        }
    }
}