﻿using System;
namespace Attributes
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
	public class TrackingProperty : Attribute
	{
		public string NameOfAttribute;

		public TrackingProperty(string name)
		{
			NameOfAttribute = name;
		}
	}
}

