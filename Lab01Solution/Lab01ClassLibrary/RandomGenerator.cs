using System;
using System.Collections.Generic;

using Lab01ClassLibrary.Resources;

namespace Lab01ClassLibrary
{
	/// <inheritdoc />
	/// <summary>
	///		Klasa implementująca interface <see cref="IGenerator" />, której źródłem danych są
	///		losowo generowane liczby typu <see cref="double" /> z przedziału [0,1]
	/// </summary>
	public class RandomGenerator : IGenerator
	{
		private int? _count;

		/// <inheritdoc />
		public IEnumerable<double> GetData()
		{
			if (!this._count.HasValue)
			{
				throw new Exception(StringRes.ParameterNotSet);
			}

			var random = new Random(DateTime.Now.Millisecond);
			for (var i = 0; i < this._count.Value; i++)
			{
				yield return random.NextDouble();
			}
		}

		/// <inheritdoc />
		public void PassParameter(object obj)
		{
			this._count = obj as int? ?? throw new Exception(string.Format(StringRes.InvalidParamType,
				              nameof(obj), nameof(RandomGenerator), nameof(Int32)));
		}
	}
}
