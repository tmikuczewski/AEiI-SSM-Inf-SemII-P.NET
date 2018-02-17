using System.Collections.Generic;
using System.Data.Entity.Migrations;

using DAL.Models;

namespace DAL.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<Context>
	{
		public Configuration()
		{
			this.AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(Context context)
		{
			context.People.AddRange(new List<Person>
			{
				new Person
				{
					Username = "tmiku",
					Password = "pass1",
					Name = "TMIKUCZEWSKI"
				},
				new Person
				{
					Username = "awrob",
					Password = "1pwd",
					Name = "Gorrion"
				}
			});
		}
	}
}