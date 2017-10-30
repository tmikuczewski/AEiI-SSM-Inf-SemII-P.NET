using System;
using System.Collections.Generic;
using System.Linq;

using Lab01ClassLibrary;

namespace ConsoleApp
{
	internal class Program
	{
		private static void Main()
		{
			var analizator = new Analizator();

			var randomGenerator = new RandomGenerator();
			randomGenerator.PassParameter(5);

			analizator.SetGenerator(randomGenerator);

			IEnumerable<double> collection = randomGenerator.GetData().ToList();

			double avg = analizator.CalculateAverage(),
				dev = analizator.CalculateDeviation();
			Console.WriteLine($"avg: {avg}\tdev: {dev}");

			const string save = "save.txt";
			FileHandler.SaveData(save, collection, out DateTime saveTime);
			Console.WriteLine($"save time: {saveTime:HH:mm:ss.fffffff}");
			IEnumerable<double> data = FileHandler.ReadData(save);
			Console.WriteLine(string.Join("\t", data));

			const string saveSort = "save-sort.txt";
			FileHandler.SaveSortedData(saveSort, collection, out saveTime);
			Console.WriteLine($"save time: {saveTime:HH:mm:ss.fffffff}");
			IEnumerable<double> dataSort = FileHandler.ReadData(saveSort);
			Console.WriteLine(string.Join("\t", dataSort));

			const string saveSer = "save-ser.txt";
			FileHandler.SaveSerializedData(saveSer, collection, out saveTime);
			Console.WriteLine($"save time: {saveTime:HH:mm:ss.fffffff}");
			IEnumerable<double> dataSer = FileHandler.ReadSerializedData(saveSer);
			Console.WriteLine(string.Join("\t", dataSer));

			// --- //

			const string dataFileName = "file.txt";
			var dataFromFile = new DataFromFile();
			dataFromFile.PassParameter(dataFileName);

			analizator.SetGenerator(dataFromFile);
			dataFromFile = dataFromFile + 1D + 2.1 + 3.2 + 4.3 + 5.4 + 10D;

			avg = analizator.CalculateAverage();
			dev = analizator.CalculateDeviation();
			Console.WriteLine($"avg: {avg}\tdev: {dev}");

			dataFromFile.DeleteFileAfterRead = true;
			try
			{
				avg = analizator.CalculateAverage();
				dev = analizator.CalculateDeviation();
				Console.WriteLine($"avg: {avg}\tdev: {dev}");
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.Message}" +
								  $"\n\t{e.InnerException.Message}" +
								  $"\n\t\t{e.InnerException.InnerException.Message}" +
								  $"\n\t\t\t{e.InnerException.InnerException.InnerException.Message}");
			}
		}
	}
}