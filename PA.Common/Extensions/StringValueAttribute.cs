using System;

namespace PA.Common.Extensions
{
	[AttributeUsage(AttributeTargets.Field)]
	public class StringValueAttribute : Attribute
	{
		public string Value { get; set; }
		public string Description { get; set; }
		public bool Visible { get; set; }
		
		public StringValueAttribute(string value, string description, bool visible = true)
		{
			Value = value;
			Description = description;
			Visible = visible;
		}
	}
}
