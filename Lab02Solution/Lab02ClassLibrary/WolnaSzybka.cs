using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab02ClassLibrary
{
	/// <summary>
	///		Klasa posiadająca dwie metody działające w nieskończoność.
	/// </summary>
	public static class WolnaSzybka
	{
		/// <summary>
		///		Metoda drukująca na ekran co dwie sekundy.
		/// </summary>
		public static void WolnaMetoda()
		{
			while (true)
			{
				Console.WriteLine($"[ThreadId: {Thread.CurrentThread.ManagedThreadId}] {nameof(WolnaMetoda)}");
				Thread.Sleep(2000);
			}
			
			// ReSharper disable once FunctionNeverReturns
		}

		/// <summary>
		///		Metoda asynchroniczna drukująca na ekran co dwie sekundy.
		/// </summary>
		public static async void WolnaMetodaAsync()
		{
			while (true)
			{
				Console.WriteLine($"[ThreadId: {Thread.CurrentThread.ManagedThreadId}] {nameof(WolnaMetodaAsync)}");
				await Task.Delay(2000);
			}
			
			// ReSharper disable once FunctionNeverReturns
		}

		/// <summary>
		///		Metoda drukująca.
		/// </summary>
		public static void SzybkaMetoda()
		{
			while (true)
			{
				Console.WriteLine($"[ThreadId: {Thread.CurrentThread.ManagedThreadId}] {nameof(SzybkaMetoda)}");
			}
			
			// ReSharper disable once FunctionNeverReturns
		}
	}
}