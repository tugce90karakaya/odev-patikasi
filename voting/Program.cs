using System;
using System.Collections.Generic;
using System.Linq;

namespace VotingApplication
{
    class Program
    {
        static Dictionary<string, string> users = new Dictionary<string, string>(); // Kullanıcı adı ve şifre
        static Dictionary<string, int> votes = new Dictionary<string, int>(); // Kategori ve oy sayısı
        static List<string> categories = new List<string>() 
        { 
            "Aksiyon Filmleri", 
            "Bilim Kurgu Filmleri", 
            "Komedi Filmleri",
            ".NET Framework",
            "Java Spring",
            "Python Django",
            "Futbol",
            "Basketbol",
            "Tenis"
        };

        static void Main(string[] args)
        {
            InitializeVotes();
            
            Console.WriteLine("Voting Uygulamasına Hoşgeldiniz!");
            
            string username = AuthenticateUser();
            
            ShowCategoriesAndVote(username);
            
            ShowResults();
        }

        static void InitializeVotes()
        {
            foreach (var category in categories)
            {
                votes[category] = 0;
            }
        }

        static string AuthenticateUser()
        {
            Console.Write("Kullanıcı adınızı girin: ");
            string username = Console.ReadLine();

            if (!users.ContainsKey(username))
            {
                Console.WriteLine("Kullanıcı bulunamadı. Kayıt olmak ister misiniz? (E/H)");
                string response = Console.ReadLine().ToUpper();

                if (response == "E")
                {
                    Console.Write("Şifre belirleyin: ");
                    string password = Console.ReadLine();
                    users[username] = password;
                    Console.WriteLine("Kayıt başarılı! Oylamaya devam edebilirsiniz.");
                }
                else
                {
                    Console.WriteLine("Oylamaya katılmak için kayıt olmalısınız.");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.Write("Şifrenizi girin: ");
                string password = Console.ReadLine();
                
                if (users[username] != password)
                {
                    Console.WriteLine("Hatalı şifre!");
                    Environment.Exit(0);
                }
            }

            return username;
        }

        static void ShowCategoriesAndVote(string username)
        {
            Console.WriteLine("\nOylama Kategorileri:");
            
            for (int i = 0; i < categories.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            Console.Write("\nOylamak istediğiniz kategori numarasını seçin: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice > 0 && choice <= categories.Count)
                {
                    string selectedCategory = categories[choice - 1];
                    votes[selectedCategory]++;
                    Console.WriteLine($"Oyunuz '{selectedCategory}' kategorisine kaydedildi. Teşekkürler {username}!");
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim!");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz giriş!");
            }
        }

        static void ShowResults()
        {
            Console.WriteLine("\nOylama Sonuçları:");
            Console.WriteLine("-----------------");
            
            int totalVotes = votes.Sum(v => v.Value);
            
            if (totalVotes == 0)
            {
                Console.WriteLine("Henüz oy kullanılmadı.");
                return;
            }

            foreach (var category in votes)
            {
                double percentage = (double)category.Value / totalVotes * 100;
                Console.WriteLine($"{category.Key}: {category.Value} oy (%{percentage:F1})");
            }
        }
    }
}