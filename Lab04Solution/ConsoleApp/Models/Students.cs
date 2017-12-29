using System.Collections.Generic;

namespace ConsoleApp.Models
{
	public class Students
	{
		public string StudentName { get; set; }
		public int GroupPoint { get; set; }
		public int StudentId { get; set; }

		public List<Students> GtStuRec()
		{
			return new List<Students>
			{
				new Students {StudentId = 1, StudentName = "A", GroupPoint = 800},
				new Students {StudentId = 2, StudentName = "B", GroupPoint = 458},
				new Students {StudentId = 3, StudentName = "C", GroupPoint = 900},
				new Students {StudentId = 4, StudentName = "D", GroupPoint = 900},
				new Students {StudentId = 5, StudentName = "E", GroupPoint = 458},
				new Students {StudentId = 6, StudentName = "F", GroupPoint = 700},
				new Students {StudentId = 7, StudentName = "G", GroupPoint = 750},
				new Students {StudentId = 8, StudentName = "H", GroupPoint = 700},
				new Students {StudentId = 9, StudentName = "I", GroupPoint = 597},
				new Students {StudentId = 10, StudentName = "J", GroupPoint = 750}
			};
		}
	}
}