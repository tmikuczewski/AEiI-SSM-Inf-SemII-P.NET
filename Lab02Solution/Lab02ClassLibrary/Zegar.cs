using System;

namespace Lab02ClassLibrary
{
	/// <summary>
	///		Klasa zgłaszająca zdarzenie co jedną sekundę.
	/// </summary>
	public class Zegar
	{
		/// <summary>
		///		Delegat reprezentujący zgłoszenie zegara.
		/// </summary>
		/// <param name="zegar">Obiekt zegara.</param>
		/// <param name="timeEventArgs">Obiekt przechowujący czas wykonania.</param>
		public delegate void ZgloszenieZegara(Zegar zegar, TimeEventArgs timeEventArgs);
		/// <summary>
		///		Zdarzenie wywoływane co jedną sekundę przez obiekt <see cref="Zegar"/>.
		/// </summary>
		public event ZgloszenieZegara Zdarzenie;
		
		/// <summary>
		///		Metoda uruchamiająca zdarzenie co sekundę.
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void Run()
		{
			int second = DateTime.Now.Second;
			while (true)
			{
				if (this.Zdarzenie == null)
				{
					throw new Exception(string.Format(Resources.DelegateNotSet, nameof(Run), string.Empty));
				}

				DateTime time = DateTime.Now;
				if (second == time.Second)
				{
					continue;
				}

				second = time.Second;

				this.Zdarzenie.Invoke(this, new TimeEventArgs(time));
			}
		}
	}
}