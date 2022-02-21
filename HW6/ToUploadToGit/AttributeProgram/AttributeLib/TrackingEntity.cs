using System;
namespace AttributesLibrary
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class TrackingEntity : Attribute
	{
		public TrackingEntity()
		{
		}
	}
}

