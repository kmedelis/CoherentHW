using System;
namespace TrainingManagmentSystem
{
	public class Lecture : CommonEducation
	{
		public string Topic;

		public Lecture(string topic, string description) : base(description)
		{
			Topic = topic;
			Description = description;
		}

		public Lecture() : base(null, null)
		{ }
	}
}

