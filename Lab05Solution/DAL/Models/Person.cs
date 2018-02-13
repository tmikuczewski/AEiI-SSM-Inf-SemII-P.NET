using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DAL.Models
{
	public class Person
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[DataMember]
		public Guid Id { get; set; }
		[Required]
		[DataMember]
		public string Login { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		[DataMember]
		public string Name { get; set; }
	}
}