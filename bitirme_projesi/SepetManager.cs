using System;
using System.Collections.Generic;
using System.Text;

namespace bitirme_projesi
{
	class SepetManager:IManager
	{

		public void Ekle(Urun urun,Urun urun1)
		{
			
			Console.WriteLine("sepete eklenen urun : " + "\n ID:" + urun.Id
				+ "\n Türü: " + urun.Tür +"\n Kazanılan Yıldızlar: "+urun.YıldızDeğeri+ "\n Adı: " + urun.Adi + "\n Fiyatı: " + urun.Fiyatı 
				+ "\n Açıklama: "+ urun.Açıklama);
			Console.WriteLine("sepete eklenen urun : " + "\n ID:" + urun1.Id
				+ "\n Türü: " + urun1.Tür + "\n Kazanılan Yıldızlar: " + urun1.YıldızDeğeri + 
				"\n Adı: " + urun1.Adi + "\n Fiyatı: " + urun1.Fiyatı + "\n Açıklama: "
				+ urun1.Açıklama);

		}

		
		public void Topla(Urun urun,Urun urun1, Customers customers)
		{
			double toplam = urun.Fiyatı+urun1.Fiyatı;
			double toplamYıldızMiktarı = urun.YıldızDeğeri+urun1.YıldızDeğeri ;
			double IndırımYapılacakYıldız = 0;
			string uruntür = urun.Tür+urun1.Tür;
			Console.WriteLine("\n Sepetteki toplam ürün miktarı: " + toplam + "\n Toplam Yıldızlarınız: " +
				toplamYıldızMiktarı + "\n Nakit Değeri: " +
					(IndırımYapılacakYıldız = (toplamYıldızMiktarı * 0.1)));

			Console.WriteLine("\n Yıldızlarınızı Kullanmak İster Misiniz?(evet/hayır) ");
			string z = "";
			z = Console.ReadLine();
			if (z == "evet")
			{
				Console.WriteLine("\n kullanılan yıldızlar: " + toplamYıldızMiktarı + " Kalan Yıldız Miktarı: 0" +
					"\n Sepetin Yıldız İndirimli Hali:" + (toplam=(toplam - IndırımYapılacakYıldız)));
			}
			else if (z == "hayır")
			{
				Console.WriteLine("kalan yıldız tutarı: " + toplamYıldızMiktarı);
			}

			if (toplam > 300)
			{

				string x = "";

				Console.WriteLine("Uygulanabilecek kampanyalar:\n " +
						"1-) 300TL ve Üzeri Alışverişlere Özel %20 İndirim Kampanyası \n " +
						"Seçmek için 1i tuşlayınız.");
				x = Console.ReadLine();

				if (x == "1")
				{
					Console.WriteLine("Birinci Kampanyayı tercih ettiniz!");
					Console.WriteLine("Sepete %20 İndirim Uygulanmış Son tutar: " + (toplam = (toplam - (toplam * 0.2))));

				}

				else
				{
					Console.WriteLine("	Kampanyayı tercih etmediniz ! \n Sepetteki son tutar: "+toplam);
				}

			}
			else
			{
				Console.WriteLine("Sepet Tutarı 300TL altında! "+(300-toplam)+" TL lik ürün eklerseniz kampanyadan yararlanabilirsiniz!");
			}

			
			if ((customers.DateOfBirth.Month == 6) & (customers.DateOfBirth.Day == 9))
			{
				string y = "";
				Console.WriteLine("Uygulanabilecek kampanyalar:\n " +
						"2-)Doğum Gününüze Özel %20 İndirim Kampanyası \n " +
						"Seçmek için 2 yi tuşlayınız.");
				y = Console.ReadLine();

						
				if (y == "2")
				{
					Console.WriteLine("Doğum Günü Kampanyasını Tercih Ettiniz\n " + (2022 - (customers.DateOfBirth.Year)) + " .Doğum Gününüz Kutlu Olsun İyiki doğdunuz!!!\n ");
					Console.WriteLine("Her doğum gününüzde bizimle olmak dileğiyle!\n " +
					"Sepetinizdeki ürünlerin indirim uygulanmış son tutarı: " + (toplam - (toplam * 0.2)));
					

				}

				else
				{
					Console.WriteLine("kampanyayı tercih etmediniz Sonraki Doğum gÜnünüzde görüşmek üzere \n Sepetteki Son tutar: "+toplam);
				}
			}
			else
			{
				Console.WriteLine("Doğum Gününüzde alışveriş yaparsanız %20 indirim kampanyası kazanırsınız");
			}











		}    

		//Kamoanyalar 1-)Toplam Ürün 300 Tl ve üstü ise %20 indirim uygula
	}
}

