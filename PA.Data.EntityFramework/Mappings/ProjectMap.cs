using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Core.Domain.Entities;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework.Mappings
{
    public class ProjectMap : MappingBase<Project>
    {
        protected override void BeforeConfigure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projeto");
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Nome");
            builder.HasOne(t => t.Client)
                .WithMany(t => t.Projects)
                .HasForeignKey("IDCliente");
        }

        protected override void ConfigureKey(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .HasColumnName("IDProjeto");
        }
    }
}