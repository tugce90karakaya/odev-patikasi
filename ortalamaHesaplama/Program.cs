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

foreach (int item in dizi)
{
    Console.Write(item+" ");
}
