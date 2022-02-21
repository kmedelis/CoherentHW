using System;
using Vacations;

Organization organization = new Organization();

//organization.VacationAdd("rimtas", new DateTime(2021, 12, 1), new DateTime(2021, 12, 31));

//Console.WriteLine(organization.AverageLength());

//organization.AverageVacationByEmployee();

//Console.WriteLine("Average vacation time by employees:");
//foreach ((string, long) element in organization.AverageVacationByEmployee()) 
//{
//    Console.WriteLine(element);
//}
//Console.WriteLine("");
//Console.WriteLine("Vacations by month:");


//DateTime experiment = new DateTime(2021, 1, 1);


//Console.WriteLine(organization.DaysWithNoVacations());

int index = 1;

Console.WriteLine("0 implies that no one took vacaion on that day:");
//foreach (int a in organization.DaysWithNoVacations())
//{ 
//    if (a == 0)
//    {
//        Console.WriteLine(index + ":" + a);
//    }
//    index++;
//}

foreach ((int, int) element in organization.VacationsByMonth())
{
    Console.WriteLine(element);
}

organization.VacationAdd("petras", new DateTime(2021, 4, 4), new DateTime(2021, 5, 1));
organization.VacationAdd("petras", new DateTime(2021, 6, 12), new DateTime(2021, 7, 1));

Console.WriteLine(organization.CheckForDupliaces()); // returns false because no overlaps

organization.VacationAdd("test", new DateTime(2021, 1, 31), new DateTime(2021, 4, 1));
organization.VacationAdd("test", new DateTime(2021, 6, 1), new DateTime(2021, 7, 1));
//organization.VacationAdd("testing", new DateTime(2021, 1, 1), new DateTime(2021, 2, 1));

Console.WriteLine(organization.CheckForDupliaces()); // returns false because no overlaps

organization.VacationAdd("petrass", new DateTime(2021, 2, 12), new DateTime(2021, 2, 14));
organization.VacationAdd("petrass", new DateTime(2021, 2, 12), new DateTime(2021, 2, 15));

Console.WriteLine(organization.CheckForDupliaces()); // returns true because overlaps

