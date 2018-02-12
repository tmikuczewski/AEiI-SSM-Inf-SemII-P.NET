using System.Collections.Generic;

namespace ConsoleApp.Models
{
	public class ItemMast
	{
		public int Id { get; set; }
		public string Descr { get; set; }

		public override string ToString() => $"ItemMast(Id:{this.Id}, Descr:'{this.Descr}')";

		public static List<ItemMast> GetList()
		{
			return new List<ItemMast>
			{
				new ItemMast {Id = 1, Descr = "A"},
				new ItemMast {Id = 2, Descr = "B"},
				new ItemMast {Id = 3, Descr = "C"},
				new ItemMast {Id = 4, Descr = "D"},
				new ItemMast {Id = 5, Descr = "E"}
			};
		}
	}
}