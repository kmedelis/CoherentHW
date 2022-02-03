using System;
namespace TrainingManagmentSystem
{
    public class Training : CommonEducation
    {
        private List<CommonEducation> Lessons;


        public Training(string description) : base(description)
        {
            Description = description;
            Lessons = new List<CommonEducation>();
        }

        public Training()
        {
            Description = null;
            Lessons = new List<CommonEducation>();
        }


        public void add(CommonEducation commonEducation)
        {
            Lessons.Add(commonEducation);
        }

        public bool isPractical()
        {
            int temp = 0;

            foreach (CommonEducation element in Lessons)
            {
                if (element is PracticalLesson)
                {
                    temp++;
                }
            }

            if (temp == Lessons.Count)
            {
                return true;
            }
            return false;
        }

        public Training Clone()
        {
            Training newTraining = new Training();
            foreach(CommonEducation element in Lessons)
            {
                newTraining.add(newTraining.add(element.Clone()););
            }
            return newTraining;
        }
    }
}

