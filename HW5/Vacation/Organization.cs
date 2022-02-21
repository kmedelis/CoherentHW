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

        public double AverageLength()
        {
            return Vacations.Average(vacation => (vacation.VacationEnd - vacation.VacationStart).Days);
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
            for (int i = 1; i < 13; i++)
            {
                int numberOfEmployees = Vacations.Where(x => x.VacationStart.Month <= i && x.VacationEnd.Month >= i).DistinctBy(x => x.Name).ToList().Count();
                (int, int) tuple = (i, numberOfEmployees);
                yield return tuple;
                numberOfEmployees = 0;
            }
        }

        public long[] DaysWithNoVacations() // I believe that an array is much more effective resource vise in this case? 
        {
            long[] daysWithNoVacation = new long[365];

            foreach (var vacation in Vacations)
            {
                long start = vacation.VacationStart.DayOfYear;
                Console.WriteLine("start: " + start);
                long end = vacation.ConvertDateToDays() + start; // end is the gap between start and end + start because the start acts as an offset. 
                Console.WriteLine("end: " + end);

                for (long i = start - 1; i < end; i++)
                {
                    daysWithNoVacation[i] = 1;
                }
            }
            return daysWithNoVacation;
        }

        public bool CheckForDupliaces() // made the code more simple this time 
        {
            var duplicates = Vacations.GroupBy(x => x.Name).Where(g => g.Count() > 1).Select(g => g.Key).ToList(); // selects all the instances of Vacation where it is repeated more than once
            foreach (var vacation in duplicates)
            {
                DateTime endPrevious = DateTime.MinValue;
                var orderedVacations = Vacations.Where(x => x.Name.Equals(vacation)).OrderBy(x => x.VacationStart).ToList(); // selects all the instances with the repeated name
                foreach (var sameVacation in orderedVacations)
                {
                    if (sameVacation.VacationStart <= endPrevious)
                    {
                        return true;
                    }
                    endPrevious = sameVacation.VacationEnd;
                }
            }
            return false;
        }
    }
}