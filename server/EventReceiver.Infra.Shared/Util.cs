using System;

namespace EventReceiver.Infra.Shared
{
    public static class Util
    {
		public static DateTime TimeStampToDate(String timestamp)
		{
			DateTime dtDateTime;

			try
            {
				int tmp = int.Parse(timestamp);
				dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(tmp).ToUniversalTime();
			}
			catch(FormatException ex)
            {
				throw new FormatException(ex.Message);
            }

			return dtDateTime;
		}
	}
}
