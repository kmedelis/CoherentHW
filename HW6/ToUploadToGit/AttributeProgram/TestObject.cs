using System;
using AttributesLibrary;

namespace Attributes
{
	[TrackingEntity]
	public class TestObject
	{
		[TrackingProperty(null)]
		public int Number { get; set; }
        [TrackingProperty("This is named")]
		public string Name { get; set; }
		[TrackingProperty("Test Field")]
		public string _prop { get; set; }
		public int NotInclude { get; set; }

		public TestObject(int number, string name, int notInclude)
		{
			Number = number;
			Name = name;
			NotInclude = notInclude;
			_prop = "asd";
		}
	}
}

