using System;

namespace Lab02ClassLibrary
{
	public class Sluchacz
	{
		private readonly Guid _guid = Guid.NewGuid();

		public void Subskrybuj(Zegar zegar, TimeEventArgs timeEventArgs)
		{
			Console.WriteLine($"[{this._guid}] {GetType()}\t{timeEventArgs.TimeSpan}");
		}
	}
}