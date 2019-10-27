namespace System
{
	public static class JulianDateTime
	{
		public static DateTime FromJulianDay(decimal julianDay)
		{
			var adjustedJD = julianDay + .5m;
			int I = (int)adjustedJD;
			decimal F = adjustedJD - I;

			int A = 0;
			int B = I;

			if (I > 2299160)
			{
				A = (int)((I - 1867216.25m) / 36524.25m);
				B = I + 1 + A - (int)(A / 4m);
			}

			int C = B + 1524;
			int D = (int)((C - 112.1m) / 365.25m);
			int E = (int)(365.25m * D);
			int G = (int)((C - E) / 30.6001m);

			var d = C - E + F - (int)(30.6001m * G);

			int m = 0;
			if (G < 13.5m)
			{
				m = G - 1;
			}
			else
			{
				m = G - 13;
			}

			int y = 0;
			if (m > 2.5)
			{
				y = D - 4716;
			}
			else
			{
				y = D - 4715;
			}

			int day = (int)d;
			decimal partialDay = d - day;

			var dayOfSeconds = 24 * 60 * 60;
			var partialSeconds = dayOfSeconds * partialDay;
			int hours = (int)(partialSeconds / (60 * 60));
			int remainingSeconds = (int)(partialSeconds % (60 * 60));
			int minutes = (int)(remainingSeconds / 60);
			int seconds = (int)(remainingSeconds % 60);

			var theDate = new DateTime(y, m, day, hours, minutes, seconds);
			return theDate;
		}
	}
}