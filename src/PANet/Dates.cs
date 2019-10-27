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
	}
}
