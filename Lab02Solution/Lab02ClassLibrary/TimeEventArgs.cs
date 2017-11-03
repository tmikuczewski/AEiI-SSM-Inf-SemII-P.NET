using System;

namespace Lab02ClassLibrary
{
	/// <inheritdoc />
	/// <summary>
	///		Klasa przechowująca infomracje na temat czasu wystąpienia zdarzenia.
	/// </summary>
	public class TimeEventArgs : EventArgs
	{
		/// <inheritdoc />
		/// <summary>
		///		Konstruktor tworzący obiekt na podstawie czasu podanego parametrem.
		/// </summary>
		/// <param name="dateTime">Czas przechowywany przez obiekt.</param>
		public TimeEventArgs(DateTime dateTime)
		{
			this.Godzina = dateTime.Hour;
			this.Minuta = dateTime.Minute;
			this.Sekunda = dateTime.Second;
		}

		/// <summary>
		///		Ilość godzin.
		/// </summary>
		public int Godzina { get; set; }
		/// <summary>
		///		Ilość minut.
		/// </summary>
		public int Minuta { get; set; }
		/// <summary>
		///		Ilość sekund.
		/// </summary>
		public int Sekunda { get; set; }

		/// <summary>
		///		Przedstawienie właściwości obiektu w postaci obiektu <see cref="TimeSpan"/>.
		/// </summary>
		public TimeSpan TimeSpan => new TimeSpan(this.Godzina, this.Minuta, this.Sekunda);
	}
}