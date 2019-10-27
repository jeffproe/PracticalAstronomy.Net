namespace System
{
	public static class Dates
	{
		public static DateTime EasterSunday(this DateTime theDate)
		{
			int a = theDate.Year % 19;
			int b = theDate.Year / 100;
			int c = theDate.Year % 100;
			int d = b / 4;
			int e = b % 4;
			int f = (b + 8) / 25;
			int g = (b - f + 1) / 3;
			int h = ((19 * a) + b - d - g + 15) % 30;
			int i = c / 4;
			int k = c % 4;
			int l = (32 + (2 * e) + (2 * i) - h - k) % 7;
			int m = (a + (11 * h) + (22 * l)) / 451;
			int n = (h + l - (7 * m) + 114) / 31;
			int p = (h + l - (7 * m) + 114) % 31;

			var easter = new DateTime(theDate.Year, n, p + 1);
			return easter;
		}

		public static decimal JulianDay(this DateTime theDate)
		{
			int y = theDate.Year;
			int m = theDate.Month;
			decimal d = theDate.FractionalDay();

			int yPrime = 0;
			int mPrime = 0;
			if (m >= 1 && m <= 2)
			{
				yPrime = y - 1;
				mPrime = m + 12;
			}
			else
			{
				yPrime = y;
				mPrime = m;
			}

			int B = 0;
			int C = (int)(365.25m * yPrime);
			var cutoff = new DateTime(1582, 10, 15);
			if (theDate > cutoff)
			{
				int a = yPrime / 100;
				B = 2 - a + ((int)(a / 4));
			}
			if (yPrime < 0)
			{
				C = (int)((365.25 * yPrime) - .75);
			}
			int D = (int)(30.6001 * (mPrime + 1));

			var jd = B + C + D + d + 1720994.5m;
			return jd;
		}

		private static decimal FractionalDay(this DateTime theDate)
		{
			var totalSeconds = theDate.Second;
			totalSeconds += (theDate.Minute * 60);
			totalSeconds += (theDate.Hour * 60 * 60);

			var dayOfSeconds = 24 * 60 * 60;

			return (decimal)theDate.Day + ((decimal)totalSeconds / (decimal)dayOfSeconds);
		}
	}
}
