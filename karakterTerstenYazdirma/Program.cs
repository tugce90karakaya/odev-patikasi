using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Metin giriniz: ");
        string input = Console.ReadLine();

        string[] kelimeler = input.Split(' ');
        for (int i = 0; i < kelimeler.Length; i++)
        {
            string kelime = kelimeler[i];
            if (kelime.Length > 1)
            {
                // Son harfi al, başa koy. Geri kalanı sona ekle
                string yeniKelime = kelime.Substring(1) + kelime[0];
                kelimeler[i] = yeniKelime;
            }
        }

        // Yeni halini birleştir ve yazdır
        string sonuc = string.Join(" ", kelimeler);
        Console.WriteLine("Çıktı: " + sonuc);
    }
}
