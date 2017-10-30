using System;
using System.Collections.Generic;
using Lab01ClassLibrary.Resources;

namespace Lab01ClassLibrary
{
	/// <inheritdoc />
	/// <summary>
	///		Klasa implementująca interface <see cref="IGenerator" />, której źródłem danych są
	///		liczby typu <see cref="double" /> zapisane w pliku
	/// </summary>
	public class DataFromFile : IGenerator
	{
		/// <summary>
		///		Parametr sterujący usuwaniem pliku po jego przeczytaniu metodą <see cref="GetData"/>
		/// </summary>
		public bool DeleteFileAfterRead { get; set; }

		private static string _dataFileName;

		/// <inheritdoc />
		public IEnumerable<double> GetData()
		{
			if (string.IsNullOrEmpty(_dataFileName))
			{
				throw new Exception(StringRes.ParameterNotSet);
			}

			IEnumerable<double> collection;
			try
			{
				collection = FileHandler.ReadData(_dataFileName);
			}
			catch (Exception e)
			{
				throw new Exception(string.Format(StringRes.ErrorOccuredSeeInnerException, ErrorsRes.ReadData), e);
			}

			if (this.DeleteFileAfterRead)
			{
				FileHandler.DeleteFile(_dataFileName);
			}

			return collection;
		}

		/// <inheritdoc />
		public void PassParameter(object obj)
		{
			_dataFileName = obj as string ?? throw new Exception(string.Format(StringRes.InvalidParamType,
				                nameof(obj), nameof(DataFromFile), nameof(String)));
		}

		/// <summary>
		/// Operator dopisywania do pliku kolejnej wartości.
		/// </summary>
		/// <param name="obj">Obiekt, do którego dopisywa jest daną.</param>
		/// <param name="value">Wartość, którą dopisuje się do obiektu.</param>
		/// <returns></returns>
		public static DataFromFile operator +(DataFromFile obj, double value)
		{
			FileHandler.SaveData(_dataFileName, new[] { value });
			return obj;
		}
	}
}