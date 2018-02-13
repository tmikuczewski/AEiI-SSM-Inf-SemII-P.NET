using System.Data.Entity;

using DAL.Models;

namespace DAL
{
	public class Context : DbContext
	{
		public Context()
			: base("name=DbConnStr")
		{
		}

		public virtual DbSet<Person> People { get; set; }
	}
}