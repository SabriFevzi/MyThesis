using bitirme_projesi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bitirme_projesi.Abstract
{
	public abstract class BaseCustomerManager : ICustomerService
	{
		public virtual void Save(Customer customer)
		{
			Console.WriteLine("saved to database: "+customer.Id +customer.FirstName+customer.LastName+customer.DateTime
				 +customer.NationalityId);
		}
	}
}
