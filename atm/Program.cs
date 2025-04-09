using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ATMApplication
{
    class Program
    {
        // Kullanıcı bilgileri (username, password, balance)
        static Dictionary<string, (string password, decimal balance)> users = new Dictionary<string, (string, decimal)>();
        
        // İşlem listesi
        static List<string> transactions = new List<string>();
        
        // Hatalı giriş denemeleri
        static List<string> failedAttempts = new List<string>();
        
        // Mevcut oturum
        static string currentUser = null;

        static void Main(string[] args)
        {
            InitializeUsers();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ATM Uygulamasına Hoşgeldiniz!");
                
                if (currentUser == null)
                {
                    AuthenticateUser();
                }
                else
                {
                    ShowMainMenu();
                }
            }
        }

        static void InitializeUsers()
        {
            // Örnek kullanıcılar
            users["user1"] = ("pass1", 1500.00m);
            users["user2"] = ("pass2", 2500.00m);
            users["admin"] = ("admin123", 10000.00m);
        }

        static void AuthenticateUser()
        {
            Console.Write("Kullanıcı Adı: ");
            string username = Console.ReadLine();
            Console.Write("Şifre: ");
            string password = Console.ReadLine();

            if (users.ContainsKey(username) && users[username].password == password)
            {
                currentUser = username;
                AddTransaction($"{DateTime.Now} - {username} oturum açtı");
                Console.WriteLine($"Hoşgeldiniz {username}! Bakiye: {users[username].balance:C}");
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
            else
            {
                string attempt = $"{DateTime.Now} - Hatalı giriş denemesi: Kullanıcı Adı: {username}";
                failedAttempts.Add(attempt);
                Console.WriteLine("Hatalı kullanıcı adı veya şifre!");
                Console.WriteLine("Tekrar denemek için bir tuşa basın...");
                Console.ReadKey();
            }
        }

        static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine($"Hoşgeldiniz, {currentUser}");
            Console.WriteLine($"Bakiye: {users[currentUser].balance:C}\n");
            
            Console.WriteLine("1. Para Çekme");
            Console.WriteLine("2. Para Yatırma");
            Console.WriteLine("3. Ödeme Yapma");
            Console.WriteLine("4. Bakiye Sorgulama");
            Console.WriteLine("5. Gün Sonu (EOD)");
            Console.WriteLine("6. Çıkış Yap");
            
            Console.Write("\nYapmak istediğiniz işlemi seçin: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WithdrawMoney();
                    break;
                case "2":
                    DepositMoney();
                    break;
                case "3":
                    MakePayment();
                    break;
                case "4":
                    CheckBalance();
                    break;
                case "5":
                    if (currentUser == "admin")
                    {
                        GenerateEndOfDayReport();
                    }
                    else
                    {
                        Console.WriteLine("Bu işlem için yetkiniz yok!");
                        Console.ReadKey();
                    }
                    break;
                case "6":
                    AddTransaction($"{DateTime.Now} - {currentUser} oturumu kapattı");
                    currentUser = null;
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    Console.ReadKey();
                    break;
            }
        }

        static void WithdrawMoney()
        {
            Console.Clear();
            Console.WriteLine("Para Çekme");
            Console.WriteLine($"Mevcut Bakiye: {users[currentUser].balance:C}");
            
            Console.Write("Çekmek istediğiniz miktarı girin: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Geçersiz miktar!");
                }
                else if (amount > users[currentUser].balance)
                {
                    Console.WriteLine("Yetersiz bakiye!");
                }
                else
                {
                    users[currentUser] = (users[currentUser].password, users[currentUser].balance - amount);
                    AddTransaction($"{DateTime.Now} - {currentUser} {amount:C} çekti. Yeni bakiye: {users[currentUser].balance:C}");
                    Console.WriteLine($"İşlem başarılı! Yeni bakiye: {users[currentUser].balance:C}");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş!");
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void DepositMoney()
        {
            Console.Clear();
            Console.WriteLine("Para Yatırma");
            Console.WriteLine($"Mevcut Bakiye: {users[currentUser].balance:C}");
            
            Console.Write("Yatırmak istediğiniz miktarı girin: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Geçersiz miktar!");
                }
                else
                {
                    users[currentUser] = (users[currentUser].password, users[currentUser].balance + amount);
                    AddTransaction($"{DateTime.Now} - {currentUser} {amount:C} yatırdı. Yeni bakiye: {users[currentUser].balance:C}");
                    Console.WriteLine($"İşlem başarılı! Yeni bakiye: {users[currentUser].balance:C}");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş!");
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void MakePayment()
        {
            Console.Clear();
            Console.WriteLine("Ödeme Yapma");
            Console.WriteLine($"Mevcut Bakiye: {users[currentUser].balance:C}");
            
            Console.WriteLine("Ödeme Türleri:");
            Console.WriteLine("1. Elektrik Faturası");
            Console.WriteLine("2. Su Faturası");
            Console.WriteLine("3. Telefon Faturası");
            Console.WriteLine("4. İnternet Faturası");
            
            Console.Write("Ödeme türünü seçin: ");
            string paymentType = Console.ReadLine();
            
            string[] paymentTypes = { "Elektrik Faturası", "Su Faturası", "Telefon Faturası", "İnternet Faturası" };
            string selectedType = "";
            
            if (int.TryParse(paymentType, out int type) && type >= 1 && type <= 4)
            {
                selectedType = paymentTypes[type - 1];
            }
            else
            {
                Console.WriteLine("Geçersiz ödeme türü!");
                Console.WriteLine("Devam etmek için bir tuşa basın...");
                Console.ReadKey();
                return;
            }
            
            Console.Write("Ödeme miktarını girin: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                if (amount <= 0)
                {
                    Console.WriteLine("Geçersiz miktar!");
                }
                else if (amount > users[currentUser].balance)
                {
                    Console.WriteLine("Yetersiz bakiye!");
                }
                else
                {
                    users[currentUser] = (users[currentUser].password, users[currentUser].balance - amount);
                    AddTransaction($"{DateTime.Now} - {currentUser} {selectedType} için {amount:C} ödedi. Yeni bakiye: {users[currentUser].balance:C}");
                    Console.WriteLine($"İşlem başarılı! {selectedType} için {amount:C} ödendi. Yeni bakiye: {users[currentUser].balance:C}");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş!");
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine($"Mevcut Bakiyeniz: {users[currentUser].balance:C}");
            AddTransaction($"{DateTime.Now} - {currentUser} bakiye sorguladı: {users[currentUser].balance:C}");
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void GenerateEndOfDayReport()
        {
            Console.Clear();
            Console.WriteLine("Gün Sonu Raporu Hazırlanıyor...");
            
            string fileName = $"EOD_{DateTime.Now:ddMMyyyy}.txt";
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktopPath, fileName);
            
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"Gün Sonu Raporu - {DateTime.Now}");
                    writer.WriteLine("=================================");
                    writer.WriteLine("\nİŞLEM GEÇMİŞİ:");
                    writer.WriteLine("--------------");
                    
                    foreach (var transaction in transactions)
                    {
                        writer.WriteLine(transaction);
                    }
                    
                    writer.WriteLine("\nHATALI GİRİŞ DENEMELERİ:");
                    writer.WriteLine("-----------------------");
                    
                    foreach (var attempt in failedAttempts)
                    {
                        writer.WriteLine(attempt);
                    }
                    
                    writer.WriteLine("\nSON DURUM:");
                    writer.WriteLine("----------");
                    
                    foreach (var user in users)
                    {
                        writer.WriteLine($"{user.Key} - Bakiye: {user.Value.balance:C}");
                    }
                }
                
                Console.WriteLine($"Rapor başarıyla oluşturuldu: {filePath}");
                AddTransaction($"{DateTime.Now} - Gün sonu raporu oluşturuldu: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Rapor oluşturulurken hata: {ex.Message}");
            }
            
            Console.WriteLine("Devam etmek için bir tuşa basın...");
            Console.ReadKey();
        }

        static void AddTransaction(string message)
        {
            transactions.Add(message);
        }
    }
}