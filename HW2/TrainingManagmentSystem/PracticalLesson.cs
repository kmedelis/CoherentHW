using System;
namespace TrainingManagmentSystem
{
	public class PracticalLesson : CommonEducation
	{
		public string LinkToTaskCondition;
		public string LinkToSolution;

		public PracticalLesson(string description, string linkToTaskCondition, string linkToSolution) : base(description) //normal constructor
		{
			LinkToTaskCondition = linkToTaskCondition;
			LinkToSolution = linkToSolution;
		}

		public PracticalLesson() // constructor for when the values are not declared
		{
			LinkToTaskCondition = null;
			LinkToSolution = null;
			Description = null;
		}
	}
}

