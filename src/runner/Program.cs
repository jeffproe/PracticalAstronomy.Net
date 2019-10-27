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
					}
				}

				Console.WriteLine("==========\n");
			}
		}

		static void EasterSunday()
		{
			try
			{
				Console.Write($"Enter year to get Easter Sunday for [{DateTime.Now.Year}]: ");
				var year = Console.ReadLine();

				bool validYear = true;
				int y = DateTime.Now.Year;
				if (!string.IsNullOrWhiteSpace(year))
				{
					if (!int.TryParse(year, out y))
					{
						validYear = false;
						Console.WriteLine("Invalid year");
					}
				}
				if (validYear)
				{
					Console.WriteLine($"\tEaster Sunday is {new DateTime(y, DateTime.Now.Month, DateTime.Now.Day).EasterSunday().ToShortDateString()}");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error calculating Easter Sunday: {0}", ex);
			}
		}
	}
}
