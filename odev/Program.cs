using System.Diagnostics;
//1.soru

Console.WriteLine("Sayi giriniz: ");
int sayi = Convert.ToInt32(Console.ReadLine());
int[] dizi = new int[sayi];

for(int i = 0; i < sayi; i++){
    Console.WriteLine("Pozitif sayi girin:");
    int sayi2 = Convert.ToInt32(Console.ReadLine());
    dizi[i] = sayi2;
}
Console.WriteLine("********************");
for(int i = 0; i < sayi; i++){
    if(dizi[i] % 2 == 0){
        Console.WriteLine(dizi[i]+" çift sayidir.");
    }
}

//2. soru



Console.WriteLine("Kac tane sayi gireceksiniz: ");
int girilecekSayi = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Sayilarin kaca bolunmesini istersiniz: ");
int bolunecekSayi = Convert.ToInt32(Console.ReadLine());

int[] dizi2 = new int[girilecekSayi];

for(int i = 0; i < girilecekSayi; i++){
    Console.Write("Sayi giriniz: ");
    int sayi2 = Convert.ToInt32(Console.ReadLine());
    dizi2[i] = sayi;
}
Console.WriteLine("**********************");

for(int i = 0; i < dizi.Length; i++){
    if(dizi[i] == bolunecekSayi || dizi[i] % bolunecekSayi == 0){
        Console.WriteLine(dizi[i]);
    }
}

//3. soru

Console.WriteLine("Kac tane kelime girilecek: ");
int kelimeSayisi = Convert.ToInt32(Console.ReadLine());

string[] dizi3 = new string[kelimeSayisi];

for(int i = 0; i < dizi.Length; i++){
    Console.Write("Kelime girin: ");
    string kelime = Console.ReadLine();
    dizi3[i] = kelime;
}
Console.WriteLine("********************");
for(int i = dizi.Length-1; i >= 0; i--){
    Console.Write(dizi[i]+" \t");
}

//4. soru

Console.WriteLine("Bir cumle girin: ");
var cumle = Console.ReadLine();

string[] kelimeDizi = cumle.Split(" ");
int harfSayisi = cumle.Length - kelimeDizi.Length+1;

Console.WriteLine(kelimeDizi.Length);
Console.WriteLine(cumle.Length);

Console.WriteLine(cumle +" cumlesindeki kelime sayisi "+kelimeDizi.Length+ " harf sayisi "+harfSayisi);