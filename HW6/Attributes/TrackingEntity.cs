using System;
namespace Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class TrackingEntity : Attribute
	{
		public TrackingEntity()
		{
		}
	}
}

