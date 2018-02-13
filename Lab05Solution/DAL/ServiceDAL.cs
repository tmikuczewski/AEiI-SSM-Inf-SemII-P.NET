using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
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

		public void AddPerson(Person person)
		{
			using (var ctx = new Context())
			{
				if (ctx.People.Any(x => x.Login == person.Login))
				{
					throw new EntityException("Osoba o podanym Login'ie już istnieje.");
				}
				person.Id = Guid.Empty;

				ctx.People.Add(person);
				ctx.SaveChanges();
			}
		}

		public void EditPerson(Person person)
		{
			using (var ctx = new Context())
			{
				Person oldPerson = ctx.People.FirstOrDefault(x => x.Id == person.Id);
				if (oldPerson == null)
				{
					throw new EntityException("Osoba o podanym Id nie istnieje.");
				}

				oldPerson.Login = person.Login;
				oldPerson.Name = person.Name;
				ctx.Entry(oldPerson).State = EntityState.Modified;
				ctx.SaveChanges();
			}
		}

		public void RemovePerson(Guid id)
		{
			using (var ctx = new Context())
			{
				Person person = ctx.People.FirstOrDefault(x => x.Id == id);
				if (person == null)
				{
					throw new EntityException("Osoba o podanym Id nie istnieje.");
				}

				ctx.People.Remove(person);
				ctx.SaveChanges();
			}
		}
	}
}