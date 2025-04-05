/*

using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    static void Main(String[] args) {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        
        // Rehber giriş sayısını oku
        int n = int.Parse(Console.ReadLine());
        
        // Rehber verilerini oku ve dictionary'e ekle
        for (int i = 0; i < n; i++)
        {
            string[] entry = Console.ReadLine().Split(' ');
            string name = entry[0];
            string phone = entry[1];
            phoneBook[name] = phone;
        }
        
        // Sorguları işle (EOF'a kadar)
        string query;
        while ((query = Console.ReadLine()) != null)
        {
            if (phoneBook.TryGetValue(query, out string phoneNumber))
            {
                Console.WriteLine($"{query}={phoneNumber}");
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
    }
}

*/
using Microsoft.VisualBasic;

Dictionary<string, string> rehber = new Dictionary<string, string>();

rehber.Add("Ali Ergin","11111");
rehber.Add("Irem Tezel","16112");
rehber.Add("Vedat Odun","11156");
rehber.Add("Beyza Demir","77611");
rehber.Add("Yusuf Yilmaz","65758");

menu();

void menu()
{
    Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
    Console.WriteLine("Yeni Numara Kaydetmek (1)");
    Console.WriteLine("Varolan Numarayi Silmek (2)");
    Console.WriteLine("Varolan Numarayi Güncelleme (3)");
    Console.WriteLine("Rehberi Listelemek (4)");
    Console.WriteLine("Rehberde Arama Yapmak (5)");
    Console.WriteLine("Cikis yap (6)");
    
    int secim = Convert.ToInt32(Console.ReadLine());

    switch (secim)
    {
        case 1:
            kisiEkle();
            menu();
            break;
        case 2:
            kisiSil();
            menu();
            break;
        case 3:
            kisiGuncelle();
            menu();
            break;
        case 4:
            kisiYazdir();
            menu();
            break;
        case 5:
            kisiAra();
            menu();
            break;
        case 6:
            Console.WriteLine("Program bitiyor.");
            Environment.Exit(0);
            break;
        default:
            /*Console.WriteLine("Gecerli bir islem yap.");
            menu();
            break;*/
            foreach (var item in rehber.Values)
            {
                Console.WriteLine(item);
            }
            break;
    }
    Console.WriteLine("*********************************************************");
}

void kisiEkle()
{
    Console.WriteLine("Kisi sayisi girin: ");
    int sayi = Convert.ToInt32(Console.ReadLine());

    for (int i = 0; i < sayi; i++)
    {
        Console.WriteLine("Kisi ismi girin: ");
        string isim = Console.ReadLine();

        Console.WriteLine("Telefon numarasi girin: ");
        string telNo = Console.ReadLine();

        // Validasyon kontrolleri
        if (telNo.Length < 5)
        {
            Console.WriteLine("Telefon numarasi 5 haneden az olamaz!");
            i--; // Döngü sayacını azaltarak aynı kişiyi tekrar sor
            continue;
        }

        if (rehber.ContainsKey(isim))
        {
            Console.WriteLine("Bu isim rehberde kayitli!");
            i--;
            continue;
        }

        if (rehber.ContainsValue(telNo))
        {
            Console.WriteLine("Bu telefon numarasi rehberde kayitli!");
            i--;
            continue;
        }

        // Tüm kontroller geçerse ekle
        rehber.Add(isim, telNo);
        Console.WriteLine($"{isim} rehbere eklendi.");
    }

    Console.WriteLine("*************************************************");
}

void kisiSil()
{
    while (true)
    {
        Console.WriteLine("Lutfen silmek istediğiniz kisinin adini giriniz (cikmak icin q):");
        string deger = Console.ReadLine();

        if (deger?.ToLower() == "q")
            break;

        if (rehber.Remove(deger))
        {
            Console.WriteLine($"{deger} rehberden silindi");
            break;
        }

        Console.WriteLine("Silinecek kayit bulunamadi. Lutfen tekrar deneyin.");
    }
}

void kisiGuncelle()
{
    while(true)
    {
        Console.WriteLine("Guncellemek istediginiz kisinin adini giriniz (cikmak icin q):");
        string arananIsim = Console.ReadLine();

        if(arananIsim?.ToLower() == "q")
            break;

        if(rehber.ContainsKey(arananIsim))
        {
            Console.WriteLine($"Mevcut telefon numarasi: {rehber[arananIsim]}");
            Console.WriteLine("Yeni telefon numarasini giriniz:");
            string yeniTelNo = Console.ReadLine();

            if(!string.IsNullOrWhiteSpace(yeniTelNo))
            {
                rehber[arananIsim] = yeniTelNo;
                Console.WriteLine($"{arananIsim} bilgileri guncellendi.");
                break;
            }
            else
            {
                Console.WriteLine("Gecersiz telefon numarasi!");
            }
        }
        else
        {
            Console.WriteLine("Kayit bulunamadi. Tekrar deneyin.");
        }
    }
}

void kisiAra(){
    Console.WriteLine("Aramak istediginiz kisinin ismini veya telefon numarasini giriniz:");
    string arananDeger = Console.ReadLine();

    // 1. Önce isimle (key) arama yap
    if (rehber.TryGetValue(arananDeger, out string telefon))
    {
        Console.WriteLine($"\nArama Sonucu:");
        Console.WriteLine($"İsim: {arananDeger}");
        Console.WriteLine($"Telefon: {telefon}");
        return;
    }

    // 2. İsim bulunamazsa telefon numarasıyla (value) arama yap
    var kayit = rehber.FirstOrDefault(x => x.Value == arananDeger);
    if (kayit.Key != null)
    {
        Console.WriteLine($"\nArama Sonucu:");
        Console.WriteLine($"İsim: {kayit.Key}");
        Console.WriteLine($"Telefon: {kayit.Value}");
        return;
    }

    // 3. Hiçbir sonuç bulunamazsa
    Console.WriteLine("\nArama Sonucu: Kayit bulunamadi");

}

void kisiYazdir()
{
    foreach (var item in rehber)
    {
        Console.WriteLine($"İsim: {item.Key}, Telefon: {item.Value}");
    }
    Console.WriteLine("********************************************");

}