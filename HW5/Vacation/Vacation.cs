using System;
namespace Vacations
{
	public class Vacation
	{
		public string Name;
		public DateTime VacationStart;
		public DateTime VacationEnd;

		public Vacation(string name, DateTime vacationStart, DateTime vacationEnd)
		{
			Name = name;
			VacationStart = vacationStart;
			VacationEnd = vacationEnd;
		}
	}
}

