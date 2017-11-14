using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab02ClassLibrary
{
	/// <summary>
	///		Klasa posiadająca dwie metody drukujące.
	/// </summary>
	public static class WolnaSzybka
	{
		/// <summary>
		///		Metoda 'pracująca dwie sekundy' i drukująca na ekran.
		/// </summary>
		public static void WolnaMetoda()
		{
			Thread.Sleep(2000);
			Console.WriteLine($"[ThreadId: {Thread.CurrentThread.ManagedThreadId}] {nameof(WolnaMetoda)}");
		}

		/// <summary>
		///		Metoda asynchroniczna 'pracująca dwie sekundy' i drukująca na ekran.
		/// </summary>
		public static async void WolnaMetodaAsync()
		{
			await Task.Delay(2000);
			Console.WriteLine($"[ThreadId: {Thread.CurrentThread.ManagedThreadId}] {nameof(WolnaMetodaAsync)}");
		}

		/// <summary>
		///		Metoda drukująca na ekran.
		/// </summary>
		public static void SzybkaMetoda()
		{
			Console.WriteLine($"[ThreadId: {Thread.CurrentThread.ManagedThreadId}] {nameof(SzybkaMetoda)}");
		}
	}
}