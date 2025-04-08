Console.WriteLine("Bir kelime ve sayi gir. Kelime ve sayi arasinda virgul olsun: ");
string deger = Console.ReadLine();

string[] dizi = deger.Split(",");

int cevir = Convert.ToInt32(dizi[1]);
string yeni = dizi[0];
for(int i = 0; i < dizi[0].Length; i++){

    if(i == cevir){
        yeni = yeni.Remove(cevir,1);
    }
    
} 

foreach (var item in yeni)
{
    Console.Write(item);
}
