using System;
using System.Collections.Generic;
using System.Threading;

namespace WpfApp.Code
{
	public static class RandomGenerator
	{
		public static IEnumerable<double> Generate(int count, double min, double max, int maxTimeInterval = 1000)
		{
			Random valuesRandom = new Random(DateTime.Now.Millisecond),
				intervalsRandom = new Random(DateTime.Now.Millisecond / 2);

			for (var i = 0; i < count; i++)
			{
				Thread.Sleep(intervalsRandom.Next(maxTimeInterval + 1));
				yield return valuesRandom.NextDouble() * (max - min) + min;
			}
		}
	}
}