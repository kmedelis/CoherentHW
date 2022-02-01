using System;
using Vacations;

namespace Vacations
{
    public class Organization
    {
        public List<Vacation> Vacations;

        public Organization()
        {
            Vacations = new List<Vacation>();
        }

        public void VacationAdd(string employeeName, DateTime start, DateTime end)
        {
            Vacations.Add(new Vacation(employeeName, start, end));
        }

        public int AverageLength()
        {
            var list = Vacations.Select(x => x.VacationEnd - x.VacationStart).ToList();
            int itemCount = list.Count;
            int days = 0;
            for (int i = 0; i < itemCount; i++)
            {
                days = days + (int)list[i].TotalDays;
            }
            int averageLength = days / itemCount;
            return averageLength;
        }

        public IEnumerable<(string, long)> AverageVacationByEmployee()
        {
            var groupVacations = from vacation in Vacations
                                 group vacation by vacation.Name into vacationGroup
                                 select new
                                 {
                                     Name = vacationGroup.Key,
                                     AverageVacationTime = vacationGroup.Sum(x => x.ConvertDateToDays()) / vacationGroup.Count(x => x.Name.Equals(vacationGroup.Key)), // this sums the total amount of days a person took and divides them by how many holidays this one person took
                                 };

            foreach (var vacation in groupVacations)
            {
                (string, long) tuple = (vacation.Name, vacation.AverageVacationTime);
                yield return tuple;
            }
        }

        public IEnumerable<(int, int)> VacationsByMonth()
        {
            int numberOfEmployees = 0;
            for (int i = 1; i < 13; i++)
            {
                foreach (var vacation in Vacations)
                {
                    if (vacation.VacationStart.Month <= i && i <= vacation.VacationEnd.Month)
                    {
                        numberOfEmployees++;
                    }
                }
                (int, int) tuple = (i, numberOfEmployees);
                yield return tuple;
                numberOfEmployees = 0;
            }
        }

        public long[] DaysWithNoVacations() // I believe that an array is much more effective resource vise in this case? 
        {
            long[] daysWhenWorked = new long[365];

            foreach (var vacation in Vacations)
            {
                long start = vacation.VacationStart.DayOfYear;
                Console.WriteLine("start: " + start);
                long end = vacation.ConvertDateToDays() + start; // end is the gap between start and end + start because the start acts as an offset. 
                Console.WriteLine("end: " + end);

                for (long i = start-1; i < end; i++)
                {
                    daysWhenWorked[i] = 1;
                }
            }
            return daysWhenWorked;
        }


        public bool CheckForDupliaces()
        {
            var listOfUnique = Vacations.Select(x => x.Name).Distinct().ToList(); // selects disctint
            foreach (var unique in listOfUnique)
            {
                var tempList = Vacations.Where(x => x.Name.Equals(unique)).ToList(); // selects all the entries with a certain name
                for (int i = 0; i < tempList.Count - 1; i++)
                {
                    if (tempList[i].VacationStart <= tempList[i + 1].VacationEnd && tempList[i + 1].VacationStart <= tempList[i].VacationEnd)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}



