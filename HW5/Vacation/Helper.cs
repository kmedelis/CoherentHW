using System;
namespace Vacations
{
	public static class Helper
	{
		public static long ConvertDateToDays(this Vacation vacation)
		{
			var date = vacation.VacationEnd - vacation.VacationStart;
			long toReturn = (long)date.TotalDays;
			return toReturn;
		}
	}
}

