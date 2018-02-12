using System.Collections.Generic;

namespace ConsoleApp.Models
{
	public class Purchase
	{
		public int No { get; set; }
		public int Id { get; set; }
		public int Qty { get; set; }

		public override string ToString() => $"Purchase(No:{this.No}, Id:{this.Id}, Qty:{this.Qty})";

		public static List<Purchase> GetList()
		{
			return new List<Purchase>
			{
				new Purchase {No = 100, Id = 3, Qty = 55},
				new Purchase {No = 101, Id = 2, Qty = 44},
				new Purchase {No = 102, Id = 3, Qty = 555},
				new Purchase {No = 103, Id = 4, Qty = 33},
				new Purchase {No = 104, Id = 3, Qty = 33},
				new Purchase {No = 105, Id = 4, Qty = 44},
				new Purchase {No = 106, Id = 1, Qty = 343}
			};
		}
	}
}