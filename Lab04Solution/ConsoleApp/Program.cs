using System;
using System.Collections.Generic;
using System.Linq;

using ConsoleApp.Models;

#region ReSharper

// ReSharper disable UnusedMember.Local
// ReSharper disable SuggestVarOrType_Elsewhere
// ReSharper disable SimilarAnonymousTypeNearby
// ReSharper disable ConvertToConstant.Local
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable InconsistentNaming

#endregion

namespace ConsoleApp
{
	internal class Program
	{
		private static void Main()
		{
			Zadania();
			Zadanie09();
			Zadanie10();
			Zadanie11();
			Zadanie12();
			Zadanie13();
			Zadanie14();
			Zadanie15();
			Zadanie16();
			Zadanie17();
			Zadanie18();
			Zadanie19();
			Zadanie19Dwa();
			Zadanie20();
		}

		private static void Zadania()
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
			Console.WriteLine($"\n\tout:\t{string.Join(", ", zad_9.Where(x => x.StartsWith(poczatek)).Where(x => x.EndsWith(koniec)))}");
		}

		private static void Zadanie10()
		{
			Console.Write(" Zad 10. Lista liczb całkowitych większa od podanej:\n\t" +
			              "  Podawaj liczby oddzielone przecinkiem i zatwierdź ENTER'em\n\t" +
			              "in:\t");
			List<int> lista = Console.ReadLine().Split(",").Select(int.Parse).ToList();
			Console.Write("\t  Podaj liczbę (zatwierdź ENTER'em): ");
			int.TryParse(Console.ReadLine(), out int min);
			Console.WriteLine($"\tout:\t{string.Join(", ", lista.FindAll(x => x > min))}\n");
		}

		private static void Zadanie11()
		{
			int[] zad_11 = {5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2};
			Console.Write(" Zad 11. Wyświetlanie 'n' ostatnich wartości z listy:\n\t" +
			              $"in:\t{string.Join(", ", zad_11)}\n\t" +
			              "  Podaj 'n' (zatwierdź ENTER'em): ");
			int.TryParse(Console.ReadLine(), out int n);
			Console.WriteLine($"\tout:\t{string.Join(", ", zad_11.TakeLast(n))}\n");
		}

		private static void Zadanie12()
		{
			int[] zad_12 = {5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2};
			Console.Write(" Zad 12. Wyświetlanie 'n' największych wartości z listy:\n\t" +
			              $"in:\t{string.Join(", ", zad_12)}\n\t" +
			              "  Podaj 'n' (zatwierdź ENTER'em): ");
			int.TryParse(Console.ReadLine(), out int n);
			Console.WriteLine($"\tout:\t{string.Join(", ", zad_12.OrderBy(x => x).TakeLast(n))}\n");
		}

		private static void Zadanie13()
		{
			var zad_13 = "Lorem ipsum DOLOR sit amet, conSECtetur adipiscing ELIT. Aenean at nisl SIT amet diam laoreet.";
			Console.WriteLine(" Zad 13. Wykrywanie słów pisanych wielkimi literami w łańcuchu znakowym:\n\t" +
			              $"in:\t{zad_13}\n\t" +
			              $"out:\t{string.Join(", ", string.Join(string.Empty, zad_13.Where(x => char.IsLetterOrDigit(x) || char.IsWhiteSpace(x))).Split(" ").Where(x => x.All(char.IsUpper)))}");
		}

		private static void Zadanie14()
		{
			string[] zad_14 = {"one", "two", "three", "four", "five"};
			Console.WriteLine(" Zad 14. Konwersja tablicy typu string na string:\n\t" +
			              $"in:\t{string.Join(", ", zad_14)}\n\t" +
			              $"out:\t{string.Join(string.Empty, zad_14)}");
		}

		private static void Zadanie15()
		{
			string StudentToString(Students std) => $"(id:{std.StudentId:D2}, name: \"{std.StudentName}\", points:{std.GroupPoint})";

			List<Students> students = new Students().GtStuRec();
			Console.Write(" Zad 15. Znajdowanie 'n' studentów, którzy uzyskali najwyższy wynik:\n\t" +
			              $"in:\t{string.Join("\n\t\t", students.Select(StudentToString))}\n\t" +
			              "  Podaj 'n' (zatwierdź ENTER'em): ");
			int.TryParse(Console.ReadLine(), out int n);
			Console.WriteLine($"\tout:\t{string.Join("\n\t\t", students.OrderBy(x => x.GroupPoint).TakeLast(n).Select(StudentToString))}");
		}

		private static void Zadanie16()
		{
			string[] zad_16 = {"a.erc", "b.txt", "c.ldd", "d.pdf", "e.PDF", "a.pdf", "b.xml", "z.txt", "zzz.doc"};
			Console.WriteLine(" Zad 14. Konwersja tablicy typu string na string:\n\t" +
			              $"in:\t{string.Join(", ", zad_16)}\n\t" +
			              $"out:\t{string.Join("\n\t\t", zad_16.Select(x => x.ToUpper()).GroupBy(x => x.Substring(x.IndexOf('.'))).Select(x => $"{x.Key.ToLower()} (ilość: {x.Count()})"))}");
		}

		private static void Zadanie17()
		{
			var zad_17 = new List<int> {5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2};
			Console.Write(" Zad 17. Usuwanie danych z listy na podstawie podanych wartości:\n\t" +
			              $"in:\t{string.Join(", ", zad_17)}\n\t" +
			              "  Wpisywane wartości zatwierdź ENTER'em; Zakończ wprowadzanie pustym wpisem\n");
			while (true)
			{
				Console.Write($"\tout:\t{string.Join(", ", zad_17)}" +
				              "\n\t  wartość: ");
				bool parsed = int.TryParse(Console.ReadLine(), out int n);
				if (!parsed)
				{
					break;
				}
				zad_17.RemoveAll(x => x == n);
			}
			Console.WriteLine();
		}

		private static void Zadanie18()
		{
			char[] zad_18_1 = {'A', 'B', 'C', 'D'};
			int[] zad_18_2 = {1, 2, 3, 4};

			Console.WriteLine(" Zad 18. Generacja iloczynu kartezjańskiego dwóch zbiorów:\n\t" +
			              $"in:\t{string.Join(", ", zad_18_1)}\n\t\t{string.Join(", ", zad_18_2)}\n\t" +
			              $"out:\t{string.Join(", ", zad_18_1.SelectMany(x => zad_18_2, (x, y) => new {x, y}).Select(x => $"{x.x}{x.y}"))}\n");
		}

		private static void Zadanie19()
		{
			List<ItemMast> itemMasts = ItemMast.GetList();
			List<Purchase> purchases = Purchase.GetList();

			Console.WriteLine(" Zad 19. Generacja złączenia typu INNER JOIN pomiędzy dwoma listami:\n\t" +
			                  $"in:\t{string.Join("\n\t\t", itemMasts)}\n\t\t{string.Join("\n\t\t", purchases)}\n\t" +
			                  $"out:\t{string.Join("\n\t\t", itemMasts.Join(purchases, x => x.Id, y => y.Id, (x, y) => $"{x} | {y}"))}\n");
		}

		private static void Zadanie19Dwa()
		{
			List<ItemMast> itemMasts = ItemMast.GetList();
			List<Purchase> purchases = Purchase.GetList();

			Console.WriteLine(" Zad 19dwa. Generacja złączenia typu LEFT JOIN pomiędzy dwoma listami:\n\t" +
			                  $"in:\t{string.Join("\n\t\t", itemMasts)}\n\t\t{string.Join("\n\t\t", purchases)}\n\t" +
			                  $"out:\t{string.Join("\n\t\t", itemMasts.GroupJoin(purchases, x => x.Id, y => y.Id, (x, y) => new { x, y }).SelectMany(z => z.y, (a, b) => $"{a.x} | {b}"))}\n");
		}

		private static void Zadanie20()
		{
			List<ItemMast> itemMasts = ItemMast.GetList();
			List<Purchase> purchases = Purchase.GetList();

			Console.WriteLine(" Zad 20. Generacja złączenia typu RIGHT JOIN pomiędzy dwoma listami:\n\t" +
			                  $"in:\t{string.Join("\n\t\t", itemMasts)}\n\t\t{string.Join("\n\t\t", purchases)}\n\t" +
			                  $"out:\t{string.Join("\n\t\t", purchases.GroupJoin(itemMasts, x => x.Id, y => y.Id, (x, y) => new { x, y }).SelectMany(z => z.y, (a, b) => $"{a.x} | {b}"))}\n");
		}
	}
}