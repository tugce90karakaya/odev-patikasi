Console.WriteLine("Ikilileri gir: ");
/*int uzunluk = Convert.ToInt32(Console.ReadLine());
int[] dizi = new int[uzunluk];

for(int i = 0; i < uzunluk; i++){
    Console.WriteLine("Sayi gir");
    int sayi = Convert.ToInt32(Console.ReadLine());
    dizi[i] = sayi;
}

for(int i = 0; i < dizi.Length; i++){

}*/
string ikili = Console.ReadLine();

string[] dizi = ikili.Split("-");

foreach (string item in dizi)
{
    string[] dizi2 = item.Split(",");
    int ilkEleman = Convert.ToInt32(dizi2[0]);
    int ikinciEleman = Convert.ToInt32(dizi2[1]);

    if(ilkEleman != ikinciEleman){
        int toplam = ilkEleman + ikinciEleman;
        Console.Write(toplam+" ");
    }
    else if(ilkEleman == ikinciEleman){
        int kare = ilkEleman*ilkEleman;
        Console.Write(kare+" ");
    }
     
}


// 2 3 1 5 2 5 3 3
// 5 6 7 81 
