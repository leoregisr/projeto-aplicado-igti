using System;
using System.Linq;
using System.Reflection;

namespace PA.Common.Extensions
{
	public static class AtributeExtensions
	{
		public static T GetAttribute<T>(this Type type)
			where T: Attribute =>
			(T) type.GetCustomAttributes(typeof(T)).FirstOrDefault();

		public static T GetAttribute<T>(this MemberInfo memberInfo)
		{
			var attributes = Attribute.GetCustomAttributes(memberInfo, typeof(T)) as T[];
			return attributes != null ? attributes.FirstOrDefault() : default(T);
		}
		public static T[] GetAttributes<T>(this MemberInfo memberInfo) =>
			Attribute.GetCustomAttributes(memberInfo, typeof(T)) as T[];

		public static T GetWithStringValue<T>(this string value)
		{
			return (T)typeof(T)
			.GetFields()
			.First(f => f.GetCustomAttributes<StringValueAttribute>()
						 .Any(a => a.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
			)
			.GetValue(null);
		}
	}
}
