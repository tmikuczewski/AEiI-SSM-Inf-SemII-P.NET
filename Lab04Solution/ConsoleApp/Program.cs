using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable SimilarAnonymousTypeNearby
// ReSharper disable ConvertToConstant.Local
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable InconsistentNaming
namespace ConsoleApp
{
	internal class Program
	{
		private static void Main()
		{
			ZadaniaStatyczne();
			Zadanie09();
			Zadanie10();
		}

		private static void ZadaniaStatyczne()
		{
			int[] zad_1_2 = {1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14};
			Console.WriteLine(" Zad 1,2. Wartości podzielne przez 2:\n\t" +
			                  $"in:\t{string.Join(", ", zad_1_2)}\n\t" +
			                  $"out:\t{string.Join(", ", zad_1_2.Where(x => (x % 2) == 0))}\n");

			int[] zad_3_4 = {3, 9, 2, 8, 6, 5};
			Console.WriteLine(" Zad 3. Wartości z przedziału [0,12]:\n\t" +
			                  $"in:\t{string.Join(", ", zad_3_4)}\n\t" +
			                  $"out:\t{string.Join(", ", zad_3_4.Where(x => x > 0).Where(x => x < 12))}\n");

			Console.WriteLine(" Zad 4. Liczby, które podniesione do drugiej potęgi dają wartość >20:\n\t" +
			                  $"in:\t{string.Join(", ", zad_3_4)}\n\t" +
			                  $"out:\t{string.Join(", ", zad_3_4.Select(x => new {x, pow = Math.Pow(x, 2)}).Where(x => x.pow > 20).Select(x => x.x))}\n");

			int[] zad_5 = {5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2};
			Console.WriteLine(" Zad 5. Liczby oraz częstotliwość ich występowania:\n\t" +
			                  $"in:\t{string.Join(", ", zad_5)}\n\t" +
			                  $"out:\t{string.Join("\n\t\t", zad_5.GroupBy(x => x).Select(x => new {x = x.Key, count = x.Count()}).Select(x => $"{x.x} (ilość: {x.count})"))}\n");

			var zad_6 = "abeddwkkecjjeksoiekcllkenndkwel";
			Console.WriteLine(" Zad 6. Litery oraz częstotliwość ich występowania:\n\t" +
			                  $"in:\t{string.Join(" ", zad_6.Select(x => x))}\n\t" +
			                  $"out:\t{string.Join("\n\t\t", zad_6.GroupBy(x => x).Select(x => new {x = x.Key, count = x.Count()}).Select(x => $"{x.x} (ilość: {x.count})"))}\n");

			string[] zad_7 = {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
			Console.WriteLine(" Zad 7. Wypisać wszystkie miesiące:\n\t" +
			                  $"in:\t{string.Join(", ", zad_7)}\n\t" +
			                  $"out:\t{string.Join(string.Empty, string.Join("\n\t\t", zad_7))}\n");

			int[] zad_8 = {5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2};
			var zad_8_list = zad_8.GroupBy(x => x).Select(x => new {x = x.Key, count = x.Count()}).ToList();
			Console.WriteLine(" Zad 8. Wypisać wszystkie miesiące:\n\t" +
			                  $"in:\t{string.Join(", ", zad_8)}\n\t" +
			                  $"out:\t{string.Join("\n\t\t", zad_8_list.Select(x => $"{x.x} (iloczyn: {x.x * x.count},\tilość: {x.count})"))}\n\t\t{zad_8_list.Sum(x => x.count)}");
		}

		private static void Zadanie09()
		{
			string[] zad_9 = {"ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS"};
			Console.Write(" Zad 9. Znajdowanie łańcuchów znaków rozpoczynających się i kończący zadanymi znakami:\n\t" +
			              $"in:\t{string.Join(", ", zad_9)}\n\t" +
			              "  Podaj dwa znaki (bez odzielającej spacji): ");
			string poczatek = Console.ReadKey().KeyChar.ToString().ToUpper();
			string koniec = Console.ReadKey().KeyChar.ToString().ToUpper();
			Console.WriteLine(
				$"\n\tout:\t{string.Join(", ", zad_9.Where(x => x.StartsWith(poczatek)).Where(x => x.EndsWith(koniec)))}");
		}

		private static void Zadanie10()
		{
			Console.Write(" Zad 10. Lista liczb całkowitych większa od podanej:\n\tin: ");
			List<int> lista = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
			Console.Write("\tmin: ");
			int min = int.Parse(Console.ReadLine());
			Console.WriteLine($"\tout: {string.Join(", ", lista.FindAll(x => x > min))}");
		}
	}
}