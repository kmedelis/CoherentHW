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
            int numberOfEmployees = 0;
            for (int i = 1; i < 13; i++)
            {
                foreach (var vacation in Vacations)
                {
                    if (vacation.VacationStart.Month <= i && vacation.VacationEnd.Month >= i)
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
            long[] daysWithNoVacation = new long[365];

            foreach (var vacation in Vacations)
            {
                long start = vacation.VacationStart.DayOfYear;
                Console.WriteLine("start: " + start);
                long end = vacation.ConvertDateToDays() + start; // end is the gap between start and end + start because the start acts as an offset. 
                Console.WriteLine("end: " + end);

                for (long i = start-1; i < end; i++)
                {
                    daysWithNoVacation[i] = 1;
                }
            }
            return daysWithNoVacation;
        }

        public bool CheckForDupliaces() // made the code more simple this time 
        {
            DateTime endPrevious = DateTime.MinValue;
            var orederedVacations = Vacations.OrderBy(x => x.VacationStart); // first order vacations by start date so that there are no need to check vacation 1 and vacation 3
            foreach (var vacation in orederedVacations)
            {
                if(vacation.VacationStart <= endPrevious)
                {
                    return true;
                }
                endPrevious = vacation.VacationEnd;
            }
            return false;
        }
    }
}


