using System;
using System.Collections.Generic;
using System.ServiceModel;

using DAL.Models;

// ReSharper disable InconsistentNaming
namespace DAL
{
	[ServiceContract]
	public interface IServiceDAL
	{
		[OperationContract]
		List<Person> GetPeople();

		[OperationContract]
		Person Find(string username, string password);

		[OperationContract]
		bool AddPerson(Person person);

		[OperationContract]
		bool EditPerson(Person person);

		[OperationContract]
		bool RemovePerson(Guid id);
	}
}