using bitirme_projesi.Abstract;
using bitirme_projesi.Entities;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Text;

namespace bitirme_projesi.Concentre
{
	public class CustomerCheckManager : ICustomerCheckService

	{
		public bool CheckIfRealPerson(Customer customer)
		{
			return true;
		}
	}
}
