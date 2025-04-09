Console.WriteLine("Bir metin giriniz: ");
string metin = Console.ReadLine();

string[] dizi = metin.Split(" ");
char a;
char b;

// merhaba
// aerhabm


foreach (string item in dizi)
{
    a = item[0];
    b = item[item.Length-1];
    string deger = b+item.Substring(1,item.Length-2)+a;
    Console.Write(deger+" ");
}
