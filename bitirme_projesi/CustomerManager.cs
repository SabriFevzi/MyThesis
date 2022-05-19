using bitirme_projesi.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MernisServiceReference;

namespace bitirme_projesi
{
	public class CustomerManager:IManager
	{
		
		public void Save(Customers customers)
		{
			
			Console.WriteLine("Müşteri database eklendi. \n" + customers.Id + "-)" + "\n Müşteri Adı: " +
			customers.FirstName + "\n Müşteri Soyadı: " + customers.LastName + "\n Müşteri Doğum Tarihi " +
			customers.DateOfBirth + "\n TCkimlik no: " + customers.NationalityId);
			
								
		}

		
		
		
	}

}
