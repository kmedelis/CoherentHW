using System;
namespace TrainingManagmentSystem
{
    public class Training : CommonEducation
    {
        private List<CommonEducation> lessons;


        public Training(string description) : base(description)
        {
            Description = description;
            lessons = new List<CommonEducation>();
        }

        public Training() : base(null, null)
        {
        }


        public void Add(CommonEducation commonEducation)
        {
            lessons.Add(commonEducation);
        }

        public bool IsPractical()
        {
            if (!(element is PracticalLesson))
            {
                return false;
            }
        }

        public Training Clone()
        {
            Training newTraining = new Training();
            foreach(CommonEducation element in lessons)
            {
                newTraining.add(element.Clone());
            }
            return newTraining;
        }
    }
}

