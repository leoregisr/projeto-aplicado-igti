using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PA.Common.Extensions;

namespace PA.Data.Repositories.EntityFramework.EF
{
	public static class EntityFrameworkExtensions
	{
		public static PropertyBuilder<TProperty> UseStringValueConversion<TProperty>(this PropertyBuilder<TProperty> propertyBuilder)
		{
			return propertyBuilder.HasConversion(
				v => typeof(TProperty).GetAttribute<StringValueAttribute>().Value,
				v => v.GetWithStringValue<TProperty>());
		}
	}
}
