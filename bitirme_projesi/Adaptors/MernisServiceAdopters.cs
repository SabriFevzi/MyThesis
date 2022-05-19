using bitirme_projesi.Abstract;
using bitirme_projesi.Entities;
using MernisServiceReference;
using System;
using System.Collections.Generic;	
using System.Text;

namespace bitirme_projesi.Adaptors
{
	public class MernisServiceAdopters : ICustomerCheckService
	{
		public bool CheckIfRealPerson(Customer customer)
		{
			KPSPublicSoapClient client = new KPSPublicSoapClient();
			return client.TCKimlikNoDoğrulaAsync(customer.NationalityId, customer.FirstName.ToUpper(), customer.LastName.ToUpper(),
				customer.DateTime.Year);


		}
	}
}
