using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using DAL.Models;

// ReSharper disable InconsistentNaming
namespace DAL
{
	public class ServiceDAL : IServiceDAL
	{
		public List<Person> GetPeople()
		{
			using (var ctx = new Context())
			{
				return ctx.People.ToList();
			}
		}

		public Person Find(string username, string password)
		{
			using (var ctx = new Context())
			{
				return password != null
					? ctx.People.FirstOrDefault(x => x.Username == username && x.Password == password)
					: ctx.People.FirstOrDefault(x => x.Username == username);
			}
		}

		public bool AddPerson(Person person)
		{
			using (var ctx = new Context())
			{
				if (ctx.People.Any(x => x.Username == person.Username))
				{
					return false;
				}
				person.Id = Guid.Empty;

				ctx.People.Add(person);
				try
				{
					ctx.SaveChanges();
				}
				catch
				{
					return false;
				}

				return true;
			}
		}

		public bool EditPerson(Person person)
		{
			using (var ctx = new Context())
			{
				Person oldPerson = ctx.People.FirstOrDefault(x => x.Id == person.Id);
				if (oldPerson == null)
				{
					return false;
				}

				oldPerson.Username = person.Username;
				oldPerson.Password = person.Password;
				oldPerson.Name = person.Name;
				ctx.Entry(oldPerson).State = EntityState.Modified;

				try
				{
					ctx.SaveChanges();
				}
				catch
				{
					return false;
				}

				return true;
			}
		}

		public bool RemovePerson(Guid id)
		{
			using (var ctx = new Context())
			{
				Person person = ctx.People.FirstOrDefault(x => x.Id == id);
				if (person == null)
				{
					return false;
				}

				ctx.People.Remove(person);
				try
				{
					ctx.SaveChanges();
				}
				catch
				{
					return false;
				}

				return true;
			}
		}
	}
}