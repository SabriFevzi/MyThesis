using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ProjectDemo
{

    public class Server
    {
        const int ServerPortNum = 3029;
        public void Listen(Action<string> loginAction)
        {
            
                //We create a socket and start the server.
                IPEndPoint serverEndPoint = new System.Net.IPEndPoint(IPAddress.Loopback, ServerPortNum);
                Socket welcomingSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                welcomingSocket.Bind(serverEndPoint);

                //Waiting for the client to connect.
                welcomingSocket.Listen(1);
                Socket connectionSocket = welcomingSocket.Accept();

                //We get the message from the client
                byte[] buffer = new byte[1024];
                int numberOfBytesReceived = connectionSocket.Receive(buffer);
                byte[] receivedBytes = new byte[numberOfBytesReceived];
                Array.Copy(buffer, receivedBytes, numberOfBytesReceived);
                string receivedMessage = Encoding.Default.GetString(receivedBytes);
                //Console.WriteLine("Getting user " + receivedMessage);
                //The message from the client is stored in the variable receivedMessage.

                //Back to the Python part
                connectionSocket.Send(receivedBytes);

                loginAction.Invoke(receivedMessage);
                
			
           
        }
    }

    #region Objects
    public class User
    {
        public int id;
        public string name;
        public string surname;
        public string gender;
        public DateTime birthDate;
        public int stars;
        public string nation;
    }

    public enum ItemType
    {
        Gomlek,
        Pantolon,
        Elbise,
        TShirt,
        Ceket,
        Hırka,
        Ayakkabı
    }

    public class Item
    {
        public int id;
        public ItemType itemType;
        public int starPrice;
        public string name;
        public double price;
        public string description;
        public int stockQuantity;
    }

    public class ShoppingCart
    {
        public List<Item> items = new List<Item>();
        public User user;
    }

    public enum PromotionType
    {
        Birthdate,
        TotalPrice,
        Star

    }

    public class Promotion
    {
        public int id;
        public string name;
        public string description;
        public PromotionType promotionType;
    }

    #endregion

    #region User Manager
    public class UserManager
    {
        public List<User> users = new List<User>();

        public UserManager()
        {
            CreateUser(1, "Sabri", "Dinç", "male", new DateTime(1999, 6, 9), "312622418850", 4);
            CreateUser(2, "Ebru", "Zorlu","female", new DateTime(2000, 5, 25), "312622418850", 2);          
            CreateUser(3, "Enes", "Kurt","male", new DateTime(2000, 5, 24), "312622418850", 2);
            CreateUser(4, "İsmail", "Kaya","male", new DateTime(1999, 11, 3), "312622418850",2);
           // CreateUser(4, "Onur", "Yalçınkaya","male", new DateTime(1999, 11, 3), "312622418850",2);
            CreateUser(5, "Mehmet", "Yalınkılıç","male",new DateTime(1999, 6, 9), "312622418850",1);
            //CreateUser(6, "Mehmet", "Yalınkılıç", new DateTime(1999, 6, 9), "312622418850",3);
        }

        private void CreateUser(int id, string name, string surname,string gender, DateTime birthDate, string nation, int stars)
        {
            users.Add(new User
            {
                id = id,
                name = name,            
                surname = surname,
                gender=gender,
                birthDate = birthDate,
                nation = nation,
                stars = stars
               
            });
        }

        public User GetUser(int id)
        {
            return users[id - 1];
        }

        public void UserAddStar(int id, int addedStars)
        {
            users[id - 1].stars += addedStars;
        }
        public void UserRemoveStar(int id, int removedStars)
        {
            users[id - 1].stars -= removedStars;
        }
    }
    #endregion

    #region Item Manager
    public class ItemManager
    {
        public List<Item> items = new List<Item>();

        public ItemManager()
        {
            ItemAdd( 1,  ItemType.Gomlek,     20, "Slim Fit Erkek Kot Gömlek",  120.90, "Yazlık", 10);
            ItemAdd( 2,  ItemType.Gomlek,     20, "Oversize Kadın Turuncu Gömlek ",  119.99, "Yazlık",  6);
            ItemAdd( 3,  ItemType.Pantolon, 30, "Siyah Bol Paça Kadın Pantolon ", 250.90,    "Yazlık", 15);
            ItemAdd( 4,  ItemType.Pantolon, 30, "Erkek Jeans Kot Pantolon", 270.90, "Yazlık", 12);
            ItemAdd( 5,  ItemType.Elbise,   40, "Askılı Mavi Elbise", 303.32, "Yazlık",  7);
            ItemAdd( 6,  ItemType.Elbise,   20, "Çok Renkli Çiçek Desenli Elbise", 169.99, "Yazlık",  8);
            ItemAdd( 7,  ItemType.TShirt,   40, "Siyah V Yaka Kadın TShirt", 110.49, "Yazlık", 15);
            ItemAdd( 8, ItemType.TShirt,   40, "Oversize Erkek Beyaz TShirt", 180.90, "Yazlık", 12);
            ItemAdd( 9, ItemType.Ceket,    50, "Siyah Deri Kadın Ceket", 429.90, "Yazlık", 10);
            ItemAdd( 10,ItemType.Ceket,    40,  "Oversize Erkek Kot Ceket", 350.90, "Yazlık", 12);
            ItemAdd( 11,ItemType.Hırka,    20,  "Unisex Siyah Fermuarlı Hırka", 158.39, "Yazlık", 10);
            ItemAdd( 12,ItemType.Hırka,    20,  "Siyah Desenli Triko Kadın Hırka", 195.49, "Yazlık",  8);
            ItemAdd( 13,ItemType.Ayakkabı, 40,  "Kontrast Platform Spor Ayakkabı", 329.95, "Yazlık", 12);
            ItemAdd( 14,ItemType.Ayakkabı, 70,  "Zımbalı Tabanlı Spor Ayakkabı", 659.95, "Yazlık", 16);
            
            


        }

        private void ItemAdd(int id, ItemType itemType, int starPrice, string name, double price, string description, int stockQuantity)
        {
            items.Add(new Item
            {
                id = id,
                itemType = itemType,
                starPrice = starPrice,
                name =name,
                price = price,
                description = description,
                stockQuantity = stockQuantity
            });
        }

        public void GetAllItems()
        {
           
         
            Console.WriteLine("Ürün kodu| Ürün Adı |Ürün Açıklaması |Ürün Tipi  |Ürün Fiyatı | Kazanılan Yıldız | Ürün Stok Durumu" );     
             
            foreach (var item in items)
            {
                Console.WriteLine($"{item.id} |{item.name} |{item.description}|{item.itemType}|{item.price} |{item.starPrice} |{item.stockQuantity}");
        
            }
        }

        public int GetItemCount()
        {
            return items.Count;
        }

        public Item GetItem(int id)
        {
            return items[id - 1];
        }
    }


    #endregion

    #region Shopping Cart Manager

    public class ShoppingCartManager
    {
        private ShoppingCart shoppingCart = new ShoppingCart();

        public void AddItem(Item item, User user)
        {

            shoppingCart.items.Add(item);
            shoppingCart.user = user;
            Console.WriteLine($"{shoppingCart.items[0].name} alışveriş sepetine eklendi. ({shoppingCart.user.name})");
        }

        public void GetAllCart()
        {
            Console.WriteLine("Ürün sırası | Ürün kodu | Ürün Adı | Ürün Açıklaması | Ürün Tipi | Ürün Fiyatı |Kazanılan Yıldız | Ürün Stok Durumu");
            var counter = 0;
            foreach (var item in shoppingCart.items)
            {
                Console.WriteLine($"{counter} | {item.id} | {item.name} | {item.description} | {item.itemType} | {item.price} | {item.starPrice} | {item.stockQuantity}");
                counter++;
            }
        }

        public Item GetItem(int itemSortValue)
        {
            return shoppingCart.items[itemSortValue];
        }

        public int GetTotalStarPrice()
        {
            var totalPrice = 0;
            foreach(var item in shoppingCart.items)
            {
                totalPrice += item.starPrice;
            }
            return totalPrice;
        }

        public int GetCartItemCount()
        {
            return shoppingCart.items.Count;
        }

        public double GetCartTotalPrice()
        {
            var totalPrice = 0.0;
            foreach(var item in shoppingCart.items)
            {
                totalPrice += item.price;
            }

            return totalPrice;
        }

        public void RemoveItem(Item item)
        {
            shoppingCart.items.Remove(item);
        }
    }

    #endregion

    #region Promotion Manager

    public class PromotionManager
    {
        private List<Promotion> promotions = new List<Promotion>();
        public PromotionManager()
        {
            AddPromotion(1, PromotionType.Birthdate, "Doğum günü indirimi", "Doğum gününe özel %20 indirim");
            AddPromotion(2, PromotionType.TotalPrice, "300 TL'ye bonus indirim", " Toplamda 300 TL ve üzeri ürün alımlarında verilen %20 indirim.");
            AddPromotion(3, PromotionType.Star, "Yıldız indirimi", "Geçmiş alışverişlerinizden biriktirdiğiniz yıldızları kullanarak yapılan indirim.");

        }

        private void AddPromotion(int id, PromotionType promotionType, string name, string description)
        {
            promotions.Add(new Promotion()
            {
                id = id,
                promotionType = promotionType,
                name = name,
                description = description
            });
        }

        public Promotion GetPromotion(int promotionId)
        {
            return promotions[promotionId - 1];
        }
    }


    #endregion


    class MainClass
    {
        private readonly static string _storeName = "ESE MAĞAZASINA";

        private static User user = null;


        #region Managers
        private static ItemManager itemManager = new ItemManager();
        private static UserManager userManager = new UserManager();
        private static ShoppingCartManager shoppingCartManager = new ShoppingCartManager();
        private static PromotionManager promotionManager = new PromotionManager();
        #endregion

        #region Actions
        public static Action<string> OnLogin;
        #endregion
         
        public static void Main(string[] args)
        {
          
            Console.WriteLine("Kullanıcı girişi bekleniyor.");
            Server server = new Server();
            server.Listen(Login);
            
            
        }
        
        private static void Login(string userId)
        {
            
            
            int userID = Int32.Parse(userId);
            user = userManager.GetUser(userID);
            if (user.gender=="male")
	        {
                 Console.WriteLine($"Merhaba {user.name} bey,  {_storeName} hoş geldiniz. \nMağazamızda şu anda {itemManager.GetItemCount()} adet ürün bulunmakta");
             }
            else if(user.gender=="female")
	        {
                Console.WriteLine($"Merhaba {user.name} hanım,  {_storeName} hoş geldiniz. \nMağazamızda şu anda {itemManager.GetItemCount()} adet ürün bulunmakta");
	        }
            itemManager.GetAllItems();
            Console.WriteLine($"Almak istediğin ürünlerin, ürün kodlarını girebilir ve alışveriş sepetine ekleyebilirsin.");
            string selectedItemId = Console.ReadLine();
            try
            {
                AddItemCart(Int32.Parse(selectedItemId));
            }
            catch
            {
                KeepShoping();
            }

            

        }

        private static void AddItemCart(int itemId)
        {
            Item item = itemManager.GetItem(itemId);
            Console.WriteLine($"{item.name} adlı ürünü sepete eklemek istediğine emin misin? ([E]evet, [H]hayır)");
            string rm = Console.ReadLine();
            if(rm == "E" || rm=="e")
            {
                shoppingCartManager.AddItem(item, user);
                Console.WriteLine($"Ürün sepete eklendi. (Sepetteki güncel eşya sayısı : {shoppingCartManager.GetCartItemCount()} Güncel sepet tutarı : {shoppingCartManager.GetCartTotalPrice()}  Kazanacağınız yıldız sayısı : {shoppingCartManager.GetTotalStarPrice()})");
         
            }
            else
            {
                Console.WriteLine("Ürün sepete eklenmekten vaz geçildi.");
            }

            KeepShoping();
        }
        private static void ShowItemCart()
        {
            Console.WriteLine("Sepetinizdeki ürünler şu şekildedir.");
            shoppingCartManager.GetAllCart();
            Console.WriteLine("Sepetten bir ürünü çıkartmak istiyorsanız [K]kaldır butonuna tıklayın, alışverişe devam etmek için [D]devam tuşuna basın.");
            string rm = Console.ReadLine();
            if(rm == "K" || rm=="k")
            {
                Console.WriteLine("Kaldırmak istediğiniz ürünün sırasını girin.");
                string lr = Console.ReadLine();
                try
                {
                    RemoveItem(Int32.Parse(lr));
                }
                catch
                {
                    ShowItemCart();
                }
            }else if(rm == "D" || rm=="d")
            {
                KeepShoping();
            }
        }

        private static void Payment()
        {
            Console.WriteLine($"Ürünlerin toplam fiyatı {shoppingCartManager.GetCartTotalPrice()}TL tutmaktadır, indirim kullanmak istermisiniz? [E]evet, [H]hayır, [Ç]çık ve alış verişe devam et.");
            string rm = Console.ReadLine();
            if(rm == "E" || rm=="e")
            {
                BonusPayment();
            }else if (rm == "H" || rm=="h")
            {
                NoBonusPayment();
            }else if (rm == "Ç" || rm =="ç")
            {
                KeepShoping();
            }
        }

        private static void NoBonusPayment()
        {
                     
            Console.WriteLine("İndirim olmadan ödeme tamamlandı."+ shoppingCartManager.GetCartTotalPrice());
            userManager.UserAddStar(user.id, shoppingCartManager.GetTotalStarPrice());
            Reset();
            
            Console.WriteLine("Alışverişe devam etmek istiyor musunuz? "+" Devam etmek için [D], İstemiyorsanız Çıkış için [Ç] basınız");
            string m = Console.ReadLine();
               if (m=="d"||m=="D")
	           {
                    KeepShoping();
	           }
               else if (m=="ç"||m=="Ç")
	           {
                    if (user.gender=="male")
	                {
                         Console.WriteLine("İyi Günler "+user.name +"  Bey");    
	                }
                    else if(user.gender=="female")
	                {
                        Console.WriteLine("İyi Günler "+user.name +"  Hanım");    
	                }      
                   

                 
                    Environment.Exit(0);
	               
	               
               }
          

        }

        private static void BonusPayment()
        {
            double totalDiscount = 0.0;
            double totalPrice = shoppingCartManager.GetCartTotalPrice();

            Console.WriteLine("Kullanılabilir indirimleriniz şunlardır.");
            if(shoppingCartManager.GetCartTotalPrice() >= 300)
            {   
                Console.WriteLine($"{promotionManager.GetPromotion(2).name} : {promotionManager.GetPromotion(2).description}");
                Console.WriteLine("indirimi uygulamak ister misiniz? (E/H)");
                string x = Console.ReadLine();
                if (x=="e" || x=="E")
	            {
                    var discount = (totalPrice * 20) / 100;
                    totalPrice -= discount;
                    totalDiscount+=discount;
                    Console.WriteLine($"İndirimden sonra ödemeniz gereken fiyat {totalPrice}TL, yapılan indirim {discount}TL");

	            }
                else
	            {
                    Console.WriteLine("İndirimi Tercih Etmediniz!");
	            }
                
            }

            if(DateTime.Now.Month == user.birthDate.Month && DateTime.Now.Day == user.birthDate.Day)
            {
               
                Console.WriteLine($"{promotionManager.GetPromotion(1).name} : {promotionManager.GetPromotion(1).description}");
                Console.WriteLine("indirimi uygulamak ister misiniz? (E/H)");
                string x = Console.ReadLine();
                if (x=="e" || x=="E")
	            {
                    var discount = (totalPrice * 20) / 100;
                    totalPrice -= discount;
                    totalDiscount+=discount;
                    Console.WriteLine($"İndirimden sonra ödemeniz gereken fiyat {totalPrice}TL, yapılan indirim {discount}TL");
	            }
                else
	            {
                    Console.WriteLine("İndirimi Tercih Etmediniz!");
	            }
                
            }

            if(shoppingCartManager.GetTotalStarPrice() > 0)
            {
              
                Console.WriteLine($"{promotionManager.GetPromotion(3).name} : {promotionManager.GetPromotion(3).description} (Şu anda {shoppingCartManager.GetTotalStarPrice()} adet yıldızınız bulunmaktadır.)");
                Console.WriteLine("indirimi uygulamak ister misiniz? (E/H)");
                string x = Console.ReadLine();
                if (x=="e"|| x=="E")
	            {
                     var discount = shoppingCartManager.GetTotalStarPrice();
                     totalPrice -= discount;
                     totalDiscount+=discount;
                     Console.WriteLine($"İndirimden sonra ödemeniz gereken fiyat {totalPrice}TL, yapılan indirim {discount}TL");
	            }
                else
	            {
                    Console.WriteLine("yıldızlarınızı kullanmadınız!  "+" Kalan yıldız sayınız:"+ shoppingCartManager.GetTotalStarPrice());
	            }
               
            }

            Console.WriteLine($"{totalPrice}TL'lik ödemeyi onaylıyor musunuz? [E]evet [H]hayır [Ç]çık ve alışverişe devam et");
            string rm = Console.ReadLine();
            if (rm == "E" || rm=="e")
            {
                Console.WriteLine($"toplamda {totalDiscount}TL'lik indirim ile {totalPrice}TL'lik ödeme tamamlandı.");
                userManager.UserRemoveStar(user.id, user.stars);
                userManager.UserAddStar(user.id, shoppingCartManager.GetTotalStarPrice());
                Reset();
               
                Console.WriteLine("Alışverişe devam etmek istiyor musunuz? "+" Devam etmek için [D], İstemiyorsanız Çıkış için [Ç] basınız");
                string m = Console.ReadLine();
                if (m=="d"||m=="D")
	            {
                     KeepShoping();
	            }
                else if (m=="ç"||m=="Ç")
	            {
                    if (user.gender=="male")
	                {
                        Console.WriteLine("İyi Günler "+user.name +" Bey"); 
	                }
                    else if (user.gender=="female")
	                {
                        Console.WriteLine("İyi Günler "+user.name +" Hanım"); 
	                }
                     
                    Environment.Exit(0);
	            }

               
                
            }
            else if (rm == "H" || rm=="h")
            {
                KeepShoping();
            }
            else if (rm == "Ç" || rm=="ç")
            {
                KeepShoping();
            }
        }

        private static void KeepShoping()
        {
            if(shoppingCartManager.GetCartItemCount() > 0)
            {
                Console.WriteLine("Alışverişe devam etmek için ürün kodunu girebilir veya ödeme yapmak için \n[Ö]ödeme tuşuna basabilirsiniz, alışveriş sepetinize bakmak için [S]sepet tuşuna basabilirsiniz.");
            }
            else
            {
                Console.WriteLine($"Almak istediğin ürünlerin, ürün kodlarını girebilir ve alışveriş sepetine ekleyebilirsin.");
            }
            string rm = Console.ReadLine();
            if(rm == "Ö" || rm=="ö")
            {
                Payment();
            }else if(rm == "S" || rm=="s")
            {
                ShowItemCart();
            }
            else
            {
                try
                {
                    AddItemCart(Int32.Parse(rm));
                }
                catch
                {
                    KeepShoping();
                }
            }

        }
        private static void RemoveItem(int itemSortValue)
        {
            Item item = shoppingCartManager.GetItem(itemSortValue);
            Console.WriteLine($"{item.name} adlı ürünü sepetten çıkartmak istediğine emin misin? [E]evet [H]hayır");
            string rm = Console.ReadLine();
            if(rm == "E" || rm=="e")
            {
                shoppingCartManager.RemoveItem(shoppingCartManager.GetItem(itemSortValue));
                Console.WriteLine($"Ürün sepetten çıkarıldı. (Sepetteki güncel eşya sayısı : {shoppingCartManager.GetCartItemCount()} Güncel sepet tutarı : {shoppingCartManager.GetCartTotalPrice()} Kazanacağınız yıldız sayısı : {shoppingCartManager.GetTotalStarPrice()})");
            }
            else if(rm == "H" || rm == "h")
            {
                Console.WriteLine($"Ürün sepetten çıkarılmaktan vaz geçildi. (Sepetteki güncel eşya sayısı : {shoppingCartManager.GetCartItemCount()} Güncel sepet tutarı : {shoppingCartManager.GetCartTotalPrice()}  Kazanacağınız yıldız sayısı : {shoppingCartManager.GetTotalStarPrice()})");
            }

            ShowItemCart();
        }

        private static void Reset()
        {
            shoppingCartManager = new ShoppingCartManager();
        }

    }
}
