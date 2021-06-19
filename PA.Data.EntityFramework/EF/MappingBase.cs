using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PA.Data.Repositories.EntityFramework.EF
{
	public abstract class MappingBase<T> : IEntityTypeConfiguration<T> where T : class
	{

		protected abstract void BeforeConfigure(EntityTypeBuilder<T> builder);
		protected abstract void ConfigureKey(EntityTypeBuilder<T> builder);

		public virtual void Configure(EntityTypeBuilder<T> builder)
		{
			BeforeConfigure(builder);
			ConfigureKey(builder);
		}
	}
}
