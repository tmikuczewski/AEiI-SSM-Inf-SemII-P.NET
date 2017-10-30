using System;
using System.Collections.Generic;
using System.Linq;

using Lab01ClassLibrary.Resources;

namespace Lab01ClassLibrary
{
	/// <summary>
	///		Klasa wykonująca operacje na danych dostarczonych przez wskazany generator.
	/// </summary>
	/// <exception cref="Exception"></exception>
	public class Analizator
	{
		private IEnumerable<double> _data;
		private IGenerator _generator;

		/// <summary>
		///		Metoda ustawiająca generator wykorzystywany przez całą klasę.
		/// </summary>
		/// <param name="generator">Obiekt generatora.</param>
		public void SetGenerator(IGenerator generator)
		{
			this._generator = generator;
			this._data = null;
		}

		/// <summary>
		///		Metoda obliczająca średnią wartość z danych dostarczonych przez generator.
		/// </summary>
		/// <returns>Wartość średnia.</returns>
		/// <exception cref="Exception"></exception>
		public double CalculateAverage()
		{
			try
			{
				LoadData();
			}
			catch (Exception e)
			{
				throw new Exception(string.Format(StringRes.ErrorOccuredSeeInnerException, ErrorsRes.CalculateAverage), e);
			}

			return this._data.Average();
		}

		/// <summary>
		///		Metoda obliczająca rozproszenie danych dostarczonych przez generator.
		/// </summary>
		/// <returns>Wartość odchylenia.</returns>
		/// <exception cref="Exception"></exception>
		public double CalculateDeviation()
		{
			try
			{
				LoadData();
			}
			catch (Exception e)
			{
				throw new Exception(string.Format(StringRes.ErrorOccuredSeeInnerException, ErrorsRes.CalculateDeviation), e);
			}

			double avg = this._data.Average();
			int count = this._data.Count();
			return Math.Sqrt(this._data.Select(x => Math.Pow(x - avg, 2)).Sum() / count);
		}

		private void LoadData()
		{
			if (this._generator == null)
			{
				throw new Exception(StringRes.GeneratorNotSet);
			}

			try
			{
				this._data = this._generator.GetData();
			}
			catch (Exception e)
			{
				throw new Exception(string.Format(StringRes.ErrorOccuredSeeInnerException, ErrorsRes.LoadDataFromGenerator), e);
			}
		}
	}
}