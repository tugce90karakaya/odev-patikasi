using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Yarıçap girin: ");
        int r = Convert.ToInt32(Console.ReadLine());

        double kalinlik = 0.4; // daire çizgisi kalınlığı
        double merkezX = r;
        double merkezY = r;

        for (int y = 0; y <= 2 * r; y++)
        {
            for (int x = 0; x <= 2 * r; x++)
            {
                double uzaklik = Math.Sqrt(Math.Pow(x - merkezX, 2) + Math.Pow(y - merkezY, 2));

                if (uzaklik >= r - kalinlik && uzaklik <= r + kalinlik)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
}
