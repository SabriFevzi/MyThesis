using System;
using System.Collections.Generic;
using System.Text;

namespace bitirme_projesi
{
	class Urun
	{
		//property-özellikj
		public int Id { get; set; }
		public string Tür { get; set; }
		public int YıldızDeğeri { get; set; }
		public string Adi { get; set; }
		public double Fiyatı { get; set; }
		public string Açıklama { get; set; }
		public int StokAdedi { get; set; }
	}
}
