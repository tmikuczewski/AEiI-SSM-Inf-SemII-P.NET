using System;

namespace Lab02ClassLibrary
{
	public class TimeEventArgs : EventArgs
	{
		public TimeEventArgs(DateTime dateTime)
		{
			this.Godzina = dateTime.Hour;
			this.Minuta = dateTime.Minute;
			this.Sekunda = dateTime.Second;
		}

		public int Godzina { get; set; }
		public int Minuta { get; set; }
		public int Sekunda { get; set; }

		public TimeSpan TimeSpan => new TimeSpan(this.Godzina, this.Minuta, this.Sekunda);
	}
}