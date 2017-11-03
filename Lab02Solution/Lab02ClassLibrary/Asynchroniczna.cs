using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lab02ClassLibrary
{
	/// <summary>
	///		Delegat reprezentujący metodę wywoływaną asynchronicznie, zwracającą <see cref="int"/>.
	/// </summary>
	/// <returns></returns>
	public delegate int IntDelegate();

	/// <summary>
	///		Klasa obsługująca wywoływanie asynchronicznie delegatów.
	/// </summary>
	public class Asynchroniczna
	{
		private event IntDelegate IntDelegate;

		/// <summary>
		///		Metoda ustawiająca delegata.
		/// </summary>
		/// <param name="del"></param>
		public void DadajDelegata(IntDelegate del) => this.IntDelegate += del;

		/// <summary>
		///		Metoda uruchamiająca asynchronicznie wszystkie metody powiązane z delegatem.
		/// </summary>
		/// <exception cref="Exception"></exception>
		public void Run()
		{
			if (this.IntDelegate == null)
			{
				throw new Exception(string.Format(Resources.DelegateNotSet, nameof(Run), $" metodą {nameof(DadajDelegata)}"));
			}

			foreach (IntDelegate del in this.IntDelegate
			                                .GetInvocationList()
			                                .Select(x => x as IntDelegate)
			                                .Where(x => x != null))
			{
				Console.WriteLine(Task.Run(() => del()).Result);
			}
		}
	}
}