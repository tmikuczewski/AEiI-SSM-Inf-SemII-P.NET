using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Lab02ClassLibrary;

namespace ConsoleApp
{
	internal class Program
	{
		// --- zad01 ---

		private const int SluchaczeCount = 3;
		private static readonly List<Sluchacz> Sluchacze = Enumerable.Range(0, SluchaczeCount)
																	 .Select(x => Activator.CreateInstance(typeof(Sluchacz)) as Sluchacz)
																	 .ToList();

		// --- /zad01 ---

		internal static void Main()
		{
			// --- zad01 ---

			var zegar = new Zegar();
			Sluchacze.ForEach(x => zegar.Zdarzenie += x.Subskrybuj);

			zegar.Run();

			// --- /zad01 ---

			// --- zad02 ---

			//Console.WriteLine($"Aktualny wątek: {Thread.CurrentThread.ManagedThreadId}");

			//// 'SzybkaMetoda' nie wykona się do momentu aż 'WolnaMetoda' nie zakończy działania.
			//WolnaSzybka.WolnaMetoda();
			//WolnaSzybka.SzybkaMetoda();

			//// 'WolnaMetoda' została uruchomiona w osobnym wątku, dlatego 'SzybkaMetoda' nie musiała
			//// na nią czekać i wykonała się pierwsza.
			//Task.Factory.StartNew(WolnaSzybka.WolnaMetoda);
			//WolnaSzybka.SzybkaMetoda();

			//// Tak jak w poprzednim przykładzie obie metody wykonywane są osobnych wątkach,
			//// lecz operacja drukowania czeka na wykonanie obu metod.
			//WolnaSzybka.WolnaMetodaAsync();
			//WolnaSzybka.SzybkaMetoda();

			Thread.Sleep(5000);
			
			// --- /zad02 ---
		}
	}
}