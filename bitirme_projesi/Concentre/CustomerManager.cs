using bitirme_projesi.Abstract;
using bitirme_projesi.Adaptors;
using bitirme_projesi.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace bitirme_projesi.Concentre
{
	public class CustomerManager:BaseCustomerManager
	{
		private ICustomerCheckService _customerCheckService;
		private MernisServiceAdopters mernisServiceAdopters;

		public CustomerManager(MernisServiceAdopters mernisServiceAdopters)
		{
			this.mernisServiceAdopters = mernisServiceAdopters;
		}

		public override void Save(Customer customer)
		{
			if (_customerCheckService.CheckIfRealPerson(customer))
			{
				base.Save(customer);
			}
			else
			{
				throw new Exception("Not a valid person ");
			}
			
			
		}

		private void CheckIfRealPerson(Customer customer)
		{
			throw new NotImplementedException();
		}
	}
}
