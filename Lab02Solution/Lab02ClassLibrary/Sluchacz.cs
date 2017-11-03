using System;

namespace Lab02ClassLibrary
{
	/// <summary>
	///		Klasa nasłuchująca zdarzenia generowane przez <see cref="Zegar"/>.
	/// </summary>
	public class Sluchacz
	{
		private readonly Guid _guid = Guid.NewGuid();

		/// <summary>
		///		Metoda wywoływane w momencie wykrycia nasłuchiwanego zdarzenia.
		/// </summary>
		/// <param name="zegar">Obiekt nasłuchwianego zegara.</param>
		/// <param name="timeEventArgs">Obiekt przechowujący informacje o czasie wystąpienia zdarzenia.</param>
		public void Subskrybuj(Zegar zegar, TimeEventArgs timeEventArgs)
		{
			Console.WriteLine($"[{this._guid}] {GetType()}\t{timeEventArgs.TimeSpan}");
		}
	}
}