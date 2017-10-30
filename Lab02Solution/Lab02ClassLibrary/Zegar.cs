using System;

namespace Lab02ClassLibrary
{
	public class Zegar
	{
		public delegate void ZgloszenieZegara(Zegar zegar, TimeEventArgs timeEventArgs);

		public event ZgloszenieZegara Zdarzenie;

		public void Run()
		{
			int second = DateTime.Now.Second;
			while (true)
			{
				if (this.Zdarzenie == null)
				{
					break;
				}

				DateTime time = DateTime.Now;
				if (second == time.Second)
				{
					continue;
				}

				second = time.Second;

				this.Zdarzenie.Invoke(this, new TimeEventArgs(time));
			}
		}
	}
}