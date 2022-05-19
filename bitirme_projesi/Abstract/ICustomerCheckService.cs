using bitirme_projesi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bitirme_projesi.Abstract
{
	public interface ICustomerCheckService
	{
		bool CheckIfRealPerson(Customer customer);
	}
}
