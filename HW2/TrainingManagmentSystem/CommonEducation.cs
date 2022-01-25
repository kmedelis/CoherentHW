using System;
namespace TrainingManagmentSystem
{
	public class CommonEducation
	{

		public string Description;

		public CommonEducation(string description)
		{
			Description = description;
		}

		public CommonEducation() //constructor for when description is not written
		{
			Description = null;
		}
	}
}

