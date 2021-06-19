using System;

namespace PA.Common.Extensions
{
	public static class StringValueAttributeExtensions
	{
		public static string GetItemValue<T>(this T enumerator) where T : struct, IConvertible => 
			(typeof(T)).GetItemValue(enumerator.ToString());

		public static string GetItemValue(this Type enumType, string enumItem) => 
			enumType.GetField(enumItem).GetAttribute<StringValueAttribute>()?.Value;

		public static string GetValue(this Enum enumerator)
		{
			var customAttributes = (StringValueAttribute[]) enumerator.GetType().GetField(enumerator.ToString())
				.GetCustomAttributes(typeof(StringValueAttribute), false);
			return customAttributes.Length != 0 ? customAttributes[0].Value : enumerator.ToString();
		}

        public static string GetDescription(this Enum enumerator)
        {
            var customAttributes = (StringValueAttribute[])enumerator.GetType().GetField(enumerator.ToString())
                .GetCustomAttributes(typeof(StringValueAttribute), false);
            return customAttributes.Length != 0 ? customAttributes[0].Description : enumerator.ToString();
        }
    }
}
