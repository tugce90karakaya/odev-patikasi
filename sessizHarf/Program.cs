
        Console.WriteLine("Bir metin gir: ");
        string metin = Console.ReadLine();
        string[] kelimeler = metin.Split(" ");

        foreach (string kelime in kelimeler)
        {
            bool ikiSessizYanYanaVar = false;
            string kucukKelime = kelime.ToLower();
            string sesliler = "aeiou";

            for (int i = 0; i < kucukKelime.Length - 1; i++)
            {
                if (!sesliler.Contains(kucukKelime[i]) && !sesliler.Contains(kucukKelime[i + 1]))
                {
                    ikiSessizYanYanaVar = true;
                    break;
                }
            }

            Console.Write(ikiSessizYanYanaVar + " ");
        }
    

