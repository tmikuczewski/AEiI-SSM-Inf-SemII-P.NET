using System;
using System.Collections.Generic;
using System.Linq;

using Lab02ClassLibrary;

namespace ConsoleApp
{
	internal class Program
	{
		// zad01

		private const int SluchaczeCount = 10;
		private static readonly List<Sluchacz> Sluchacze = Enumerable.Range(0, SluchaczeCount)
																	 .Select(x => Activator.CreateInstance(typeof(Sluchacz)) as Sluchacz)
																	 .ToList();

		internal static void Main()
		{
			var zegar = new Zegar();
			Sluchacze.ForEach(x => zegar.Zdarzenie += x.Subskrybuj);

			zegar.Run();
		}

		// /zad01

		// zad02

		//private static readonly List<IntDelegate> Delegaty = Enumerable.Range(0, 10)
		//															   .Select<int, IntDelegate>(x => () => Pow(x)).ToList();

		//public static int Pow(int a) => (int)Math.Pow(a, a);

		//internal static void Main()
		//{
		//	var asynchroniczna = new Asynchroniczna();
		//	Delegaty.ForEach(x => asynchroniczna.DadajDelegata(x));

		//	asynchroniczna.Run();
		//}

		// /zad02
	}
}