using System.Collections.Generic;

namespace Lab01ClassLibrary
{
	/// <summary>
	///     Interfejs udostępniający implementującemu funkcjonalność generacji/odczytu listy
	///		obiektów typu <see cref="IEnumerable{T}" />, gdzie T to <see cref="double"/> 
	/// </summary>
	public interface IGenerator
	{
		/// <summary>
		///     Pobiera i zwraca dane ze źródła.
		/// </summary>
		/// <exception cref="System.Exception"></exception>
		/// <returns></returns>
		IEnumerable<double> GetData();

		/// <summary>
		///     Ustawia źródło danych.
		/// </summary>
		/// <param name="obj">Typ i wartość opisująca źródło danych.</param>
		/// <exception cref="System.Exception"></exception>
		void PassParameter(object obj);
	}
}