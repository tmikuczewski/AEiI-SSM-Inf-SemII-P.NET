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
		void AddPerson(Person person);

		[OperationContract]
		void EditPerson(Person person);

		[OperationContract]
		void RemovePerson(Guid id);
	}
}