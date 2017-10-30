using System;
using System.Collections.Generic;
using System.Linq;

using Lab02ClassLibrary;

namespace ConsoleApp
{
	internal class Program
	{
		public const int SluchaczeCount = 10;

		internal static void Main()
		{
			var zegar = new Zegar();
			List<Sluchacz> sluchacze = Enumerable.Range(0, SluchaczeCount)
			                                     .Select(x => Activator.CreateInstance(typeof(Sluchacz)) as Sluchacz).ToList();

			sluchacze.ForEach(x => zegar.Zdarzenie += x.Subskrybuj);

			zegar.Run();
		}
	}
}