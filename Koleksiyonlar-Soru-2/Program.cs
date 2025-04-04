using System.Collections;

ArrayList array = new ArrayList();
ArrayList enKucuk = new ArrayList();
ArrayList enBuyuk = new ArrayList();

int toplam = 0, toplam2 = 0;


for(int i = 0; i < 20; i++){
    Console.WriteLine("Sayi giriniz: ");
    int sayi = Convert.ToInt32(Console.ReadLine());
    array.Add(sayi);
}
foreach (var item in array)
{
    Console.Write(item+" ");
}
array.Sort();
Console.Write("\n");
Console.WriteLine("***siralanmis***");

foreach (var item in array)
{
    Console.Write(item+" ");
}

for(int i = 0; i < 3; i++){
    enKucuk.Add(array[i]);
}

for(int i = array.Count-1; i > array.Count-4; i--){
    
    enBuyuk.Add(array[i]);
    
}
Console.Write("\n");
Console.WriteLine("*****en kucuk*****");
foreach (var item in enKucuk)
{
    Console.Write(item+" ");
    toplam = toplam + (int)item;
}
int ortalama = toplam/3;
Console.Write("\n");
Console.Write("Ortalama: "+ortalama);
Console.Write("\n");
Console.WriteLine("*****en buyuk*****");
foreach (var item in enBuyuk)
{
    Console.Write(item+" ");
    toplam2 = toplam2 + (int)item;
}
int ortalama2 = toplam2/3;
int ortalamaToplamlari = ortalama+ortalama2;
Console.Write("\n");
Console.Write("Ortalama: "+ortalama2);
Console.Write("\n");
Console.Write("Ortalama toplamlari: "+ortalamaToplamlari);




