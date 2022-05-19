using bitirme_projesi.Abstract;
using bitirme_projesi.Adaptors;
using bitirme_projesi.Concentre;
using bitirme_projesi.Entities;
using System;
using MernisServiceReference;
namespace bitirme_projesi
{
	class Program
	{
		static void Main(string[] args)
		{
			Urun urun1 = new Urun() {Id = 1,Tür = "Gömlek",YıldızDeğeri=20, Adi = "Slim Fit Erkek Kot Gömlek",Fiyatı = 120.90,
			Açıklama = "yazlık"	};
			
			Urun urun2 = new Urun() {Id = 2,Tür = "Gömlek",YıldızDeğeri=30, Adi = "Kadın Turuncu Oversıze Gömlek",Fiyatı = 119.99,
			Açıklama = ""};
			
			Urun urun3 = new Urun() { Id = 3,Tür = "Pantolon",YıldızDeğeri=10, Adi = "Siyah yüksek Bel Kadın Pantolon",Fiyatı = 195.99,
			Açıklama = ""};
			
			Urun urun4 = new Urun() {Id = 4,Tür = "Pantolon",YıldızDeğeri=50, Adi = "Erkek Gri Jugger Pantolon",Fiyatı = 126.96,
			Açıklama = ""};
			
			Urun urun5 = new Urun() {Id = 5,Tür = "Elbise",YıldızDeğeri=60, Adi = "Kalp Yaka Büzgülü Dokuma Viskon Elbise",Fiyatı = 227.16,
			Açıklama = ""};
			
			Urun urun6 = new Urun() {Id = 6,Tür = "Elbise",YıldızDeğeri=100, Adi = "Kuşaklı Elbise",Fiyatı = 232.21,Açıklama = ""};

			Urun urun7 = new Urun() {Id = 7,Tür = "T-Shirt",YıldızDeğeri=80, Adi = "Erkek Siyah Polo Yaka T-Shirt",Fiyatı = 123.49,
			Açıklama = ""};			

			Urun urun8 = new Urun() {Id = 8,Tür = "Ceket",YıldızDeğeri=5, Adi = "Italyan Stil Erkek Slim Fit Blazer Tek Ceket",Fiyatı = 314.10,
			Açıklama = ""  };
			
			Urun urun9 = new Urun() {Id = 9,Tür = "Hırka",YıldızDeğeri=90, Adi = "Kadın Oversize Model Hırka ",Fiyatı = 166.32,
			Açıklama = ""   };			
			{}
			Urun urun10 = new Urun() {Id = 10,Tür = "Ayakkabı",YıldızDeğeri=120, Adi = "Siyah Unisex Trekking Ayakkabı",Fiyatı = 249.99,
			Açıklama = ""  };



		
			//Console.WriteLine("_____________Metotlar___________________");
			//instance -örnek
			//encapsulation 
			

			// -------------CUSTOMER DATABASE------------
			Customers customer1 = new Customers() { Id = 1, FirstName = "Sabri Fevzi", LastName = "Dinç", 
				DateOfBirth=new DateTime(1999,6,9),NationalityId="312622418850"
			};
			Customers customer2 = new Customers()	{Id = 2,FirstName = "Ebru",LastName = "Zorlu",
				DateOfBirth = new DateTime(2000, 5, 5),
				NationalityId = "34252241450"
			};
			Customers customer3 = new Customers()	{Id = 3,FirstName = "Onur",	LastName = "Yalçınkaya",
				DateOfBirth = new DateTime(1999, 6, 4),
				NationalityId = "31292241450"
			};
			Customers customer4 = new Customers()	{Id = 4,FirstName = "Enes",LastName = "Kurt",
				DateOfBirth = new DateTime(1999, 4, 4),
				NationalityId = "45292241450"
			};

			//CustomerManager customers = new CustomerManager();
			//customers.Save(customer1);
			

			SepetManager sepetmanager = new SepetManager();
			
			sepetmanager.Ekle(urun1,urun2);
			
			sepetmanager.Topla(urun1,urun2,customer2);

			//type safe-tip güvenli
			//foreach (Urun urun in urunler)
			//{
			//Console.WriteLine("sepete eklenen urunler: "+ urunler);
			//Console.WriteLine(urun.Id);
			//Console.WriteLine(urun.Tür);
			//Console.WriteLine(urun.Adi);
			//Console.WriteLine(urun.Fiyatı);
			//Console.WriteLine(urun.Açıklama);
			Console.WriteLine("--------------------");
			//	}


			//sepetmanager.Ekle2("Armut", "yeşil armut", 12,10);
			//sepetmanager.Ekle2("Elma", "yeşil elma", 12,9);
			//sepetmanager.Ekle2("Karpuz", "Diyarbakır karpuzu ", 12,8);


		
			//Console.ReadLine();


		}
	}
}
