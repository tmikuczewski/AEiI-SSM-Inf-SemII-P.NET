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

			//// 'SzybkaMetoda' nigdy się nie wykona, ponieważ 'WolnaMetoda' wstrzymuje cały 
			//// wątek swoim działaniem.
			//WolnaSzybka.WolnaMetoda();
			//WolnaSzybka.SzybkaMetoda();

			//// Obie metody mogą wykonywać się niezależnie, ponieważ 'WolnaMetoda'
			//// została przez system uruchomiona w osobnym wątku ('StartNew' in 'TaskFactory').
			//Task.Factory.StartNew(WolnaSzybka.WolnaMetoda);
			//WolnaSzybka.SzybkaMetoda();

			//// Obie metody mogą wykonywać się niezależnie, ponieważ 'WolnaMetoda' została uruchomiona
			//// asynchronicznie i zawiera w sobie kod wywoływany asynchronicznie ('Task.Delay').
			//WolnaSzybka.WolnaMetodaAsync();
			//WolnaSzybka.SzybkaMetoda();

			// --- /zad02 ---
		}
	}
}