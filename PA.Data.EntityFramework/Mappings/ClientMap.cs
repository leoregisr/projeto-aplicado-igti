using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Core.Domain.Entities;
using PA.Data.Repositories.EntityFramework.EF;

namespace PA.Data.Repositories.EntityFramework.Mappings
{
    public class ClientMap : MappingBase<Client>
    {
        protected override void BeforeConfigure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Cliente");
            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Nome");
        }

        protected override void ConfigureKey(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .UseIdentityColumn()
                .HasColumnName("IDCliente");
        }
    }
}