Console.WriteLine("Fibonacci derinligini giriniz: ");
int derinlik = Convert.ToInt32(Console.ReadLine());

int[] dizi = new int[derinlik];
dizi[0] = 1;
dizi[1] = 1;
int toplam = 2;


for(int i = 2; i < derinlik; i++){
    toplam = dizi[i-1] + dizi[i-2];
    dizi[i] = toplam;
}

float toplam2 = 0;

foreach (int item in dizi)
{
    toplam2 = toplam2 + item;
    Console.Write(item+" ");
    
}
float ortalama = toplam2 / dizi.Length;

Console.WriteLine("Ortalama: "+ortalama);


