using System;

namespace runner
{
	class Program
	{
		static void Main(string[] args)
		{
			bool run = true;
			while (run)
			{
				Console.WriteLine("PANet\n");

				Console.WriteLine("1) Easter Sunday");
				Console.WriteLine("2) Julian Day");
				Console.WriteLine("Q) Quit");

				Console.Write("\nSelection: ");

				var option = Console.ReadLine();

				if (option.Equals("q", StringComparison.OrdinalIgnoreCase))
				{
					run = false;
					continue;
				}

				int opt = 0;
				if (int.TryParse(option, out opt))
				{
					switch (opt)
					{
						case 1:
							EasterSunday();
							break;

						case 2:
							JulianDay();
							break;
					}
				}

				Console.WriteLine("==========\n");
			}
		}

		private static void JulianDay()
		{
			Console.Write($"Enter year of date to convert to Julian Day [{DateTime.Now.Year}]: ");
			var y = Console.ReadLine();
			Console.Write($"Enter month [{DateTime.Now.Month}]: ");
			var m = Console.ReadLine();
			Console.Write($"Enter day [{DateTime.Now.Day}]: ");
			var d = Console.ReadLine();
			Console.Write($"Enter hours [{DateTime.Now.Hour}]: ");
			var h = Console.ReadLine();
			Console.Write($"Enter minutes [{DateTime.Now.Minute}]: ");
			var min = Console.ReadLine();

			int year = DateTime.Now.Year;
			int month = DateTime.Now.Month;
			int day = DateTime.Now.Day;
			int hour = DateTime.Now.Hour;
			int minute = DateTime.Now.Minute;

			if (!string.IsNullOrWhiteSpace(y))
			{
				int.TryParse(y, out year);
			}
			if (!string.IsNullOrWhiteSpace(m))
			{
				int.TryParse(m, out month);
			}
			if (!string.IsNullOrWhiteSpace(d))
			{
				int.TryParse(d, out day);
			}
			if (!string.IsNullOrWhiteSpace(h))
			{
				int.TryParse(h, out hour);
			}
			if (!string.IsNullOrWhiteSpace(min))
			{
				int.TryParse(min, out minute);
			}

			var newDate = new DateTime(year, month, day, hour, minute, 0);
			Console.WriteLine($"\n\tJulian Day is: {newDate.JulianDay()}");
		}

		private static void EasterSunday()
		{
			try
			{
				Console.Write($"Enter year to get Easter Sunday for [{DateTime.Now.Year}]: ");
				var y = Console.ReadLine();

				bool validYear = true;
				int year = DateTime.Now.Year;
				if (!string.IsNullOrWhiteSpace(y))
				{
					if (!int.TryParse(y, out year))
					{
						validYear = false;
						Console.WriteLine("Invalid year");
					}
				}
				if (validYear)
				{
					Console.WriteLine($"\n\tEaster Sunday is {new DateTime(year, DateTime.Now.Month, DateTime.Now.Day).EasterSunday().ToShortDateString()}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error calculating Easter Sunday: {0}", ex);
			}
		}
	}
}
