using bitirme_projesi.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace bitirme_projesi.Entities
{
	public class Customer:IEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateTime { get; set; }
		public string NationalityId { get; set; }
		public DateTime DateOfBirth { get; internal set; }
	}
}
