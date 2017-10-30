using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

using Lab01ClassLibrary.Resources;

namespace Lab01ClassLibrary
{
	/// <summary>
	///		Klasa obsługująca operacje wykonywane na plikach.
	/// </summary>
	/// <exception cref="Exception"></exception>
	public static class FileHandler
	{
		/// <summary>
		///		Metoda odczytująca dane z pliku.
		/// </summary>
		/// <param name="fileName">Ścieżka do pliku.</param>
		/// <returns>Listę liczb odczytanych z pliku.</returns>
		/// <exception cref="Exception"></exception>
		public static IEnumerable<double> ReadData(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new Exception(StringRes.FileNameNotSet);
			}

			if (!File.Exists(fileName))
			{
				throw new Exception(string.Format(StringRes.FileNotFound, fileName));
			}

			return File.ReadAllLines(fileName).Select(x =>
			{
				if (double.TryParse(x, out double value))
				{
					return value;
				}

				throw new Exception(string.Format(StringRes.FileContainsInvalidData, fileName, nameof(Double)));
			});
		}

		/// <summary>
		///		Metoda zapisująca kolekcję liczb do zadanego pliku.
		/// </summary>
		/// <param name="fileName">Ścieżka do pliku.</param>
		/// <param name="collection">Lista liczb, która ma zostać zapisana.</param>
		/// <exception cref="Exception"></exception>
		public static void SaveData(string fileName, IEnumerable<double> collection)
		{
			ValidateFile(fileName);

			File.AppendAllText(fileName, string.Join("\n", collection));
		}

		/// <summary>
		///		Metoda zapisująca kolekcję liczb do zadanego pliku
		///		oraz mierząca czas potrzebny do wykonania zapisu.
		/// </summary>
		/// <param name="fileName">Ścieżka do pliku.</param>
		/// <param name="collection">Lista liczb, która ma zostać zapisana.</param>
		/// <param name="saveTime">Czas zapisu.</param>
		/// <exception cref="Exception"></exception>
		public static void SaveData(string fileName, IEnumerable<double> collection, out DateTime saveTime)
		{
			ValidateFile(fileName);

			Stopwatch stopwatch = Stopwatch.StartNew();
			File.AppendAllText(fileName, string.Join("\n", collection));
			stopwatch.Stop();

			saveTime = new DateTime(stopwatch.ElapsedTicks);
		}

		/// <summary>
		///		Metoda zapisująca posortowaną kolekcję liczb do zadanego pliku.
		/// </summary>
		/// <param name="fileName">Ścieżka do pliku.</param>
		/// <param name="collection">Lista liczb, która ma zostać zapisana.</param>
		/// <exception cref="Exception"></exception>
		public static void SaveSortedData(string fileName, IEnumerable<double> collection)
		{
			ValidateFile(fileName);

			List<double> list = collection.ToList();
			list.Sort();

			File.AppendAllText(fileName, string.Join("\n", list));
		}

		/// <summary>
		///		Metoda zapisująca posortowaną kolekcję liczb do zadanego pliku
		///		oraz mierząca czas potrzebny do wykonania zapisu.
		/// </summary>
		/// <param name="fileName">Ścieżka do pliku.</param>
		/// <param name="collection">Lista liczb, która ma zostać zapisana.</param>
		/// <param name="saveTime">Czas zapisu.</param>
		/// <exception cref="Exception"></exception>
		public static void SaveSortedData(string fileName, IEnumerable<double> collection, out DateTime saveTime)
		{
			ValidateFile(fileName);

			List<double> list = collection.ToList();
			list.Sort();

			Stopwatch stopwatch = Stopwatch.StartNew();
			File.AppendAllText(fileName, string.Join("\n", list));
			stopwatch.Stop();

			saveTime = new DateTime(stopwatch.ElapsedTicks);
		}

		/// <summary>
		///		Metoda zapisująca kolekcję liczb w postaci JSON do zadanego pliku.
		/// </summary>
		/// <param name="fileName">Ścieżka do pliku.</param>
		/// <param name="collection">Lista liczb, która ma zostać zapisana.</param>
		/// <exception cref="Exception"></exception>
		public static void SaveSerializedData(string fileName, IEnumerable<double> collection)
		{
			ValidateJsonFile(fileName);

			string collectionJson;
			try
			{
				collectionJson = JsonConvert.SerializeObject(collection);
			}
			catch (Exception e)
			{
				throw new Exception(string.Format(StringRes.ErrorOccuredSeeInnerException, ErrorsRes.SerializeData), e);
			}

			File.WriteAllText(fileName, collectionJson);
		}

		/// <summary>
		///		Metoda zapisująca kolekcję liczb w postaci JSON do zadanego pliku
		///		oraz mierząca czas potrzebny do wykonania zapisu.
		/// </summary>
		/// <param name="fileName">Ścieżka do pliku.</param>
		/// <param name="collection">Lista liczb, która ma zostać zapisana.</param>
		/// <param name="saveTime">Czas zapisu.</param>
		/// <exception cref="Exception"></exception>
		public static void SaveSerializedData(string fileName, IEnumerable<double> collection, out DateTime saveTime)
		{
			ValidateJsonFile(fileName);

			string collectionJson;
			try
			{
				collectionJson = JsonConvert.SerializeObject(collection);
			}
			catch (Exception e)
			{
				throw new Exception(string.Format(StringRes.ErrorOccuredSeeInnerException, ErrorsRes.SerializeData), e);
			}

			Stopwatch stopwatch = Stopwatch.StartNew();
			File.WriteAllText(fileName, collectionJson);
			stopwatch.Stop();

			saveTime = new DateTime(stopwatch.ElapsedTicks);
		}

		/// <summary>
		///		Metoda odczytująca kolekcję liczb z zadanego pliku
		/// </summary>
		/// <param name="fileName">Ścieżka do pliku.</param>
		/// <exception cref="Exception"></exception>
		public static IEnumerable<double> ReadSerializedData(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new Exception(StringRes.FileNameNotSet);
			}

			if (!File.Exists(fileName))
			{
				throw new Exception(string.Format(StringRes.FileNotFound, fileName));
			}

			string fileContent = File.ReadAllText(fileName);

			IEnumerable<double> collection;
			try
			{
				collection = JsonConvert.DeserializeObject<IEnumerable<double>>(fileContent);
			}
			catch (Exception e)
			{
				throw new Exception(string.Format(StringRes.ErrorOccuredSeeInnerException, ErrorsRes.DeserializeData), e);
			}

			return collection;
		}

		/// <summary>
		///		Metoda usuwająca plik z dysku.
		/// </summary>
		/// <param name="fileName">Ścieżka do pliku.</param>
		public static void DeleteFile(string fileName) => File.Delete(fileName);

		private static void ValidateFile(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new Exception(StringRes.FileNameNotSet);
			}

			if (File.Exists(fileName))
			{
				File.AppendAllText(fileName, Environment.NewLine);
			}
		}

		private static void ValidateJsonFile(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new Exception(StringRes.FileNameNotSet);
			}

			if (File.Exists(fileName))
			{
				File.Delete(fileName);
			}
		}
	}
}