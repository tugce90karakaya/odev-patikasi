using System;
using System.Collections;

ArrayList arrayAsal = new ArrayList();
ArrayList arrayAsalDegil = new ArrayList();

sayiGir();

void sayiGir(){

    for(int i = 0; i < 5; i++){
    Console.WriteLine("sayi gir:");
    int sayi = Convert.ToInt32(Console.ReadLine());
    if(sayi > 0){
        asalMi(sayi);
    }
    else{
        Console.WriteLine("negatif sayi girilemez");
        i--;
    }
    

}

}

ekranaYazdir();
ortalamaVeSiralama();

void asalMi(int sayi){
    if (sayi < 2){
        arrayAsalDegil.Add(sayi);
        return;
    }
    
    bool asal = true;
    for (int i = 2; i <= Math.Sqrt(sayi); i++) 
    {
        if (sayi % i == 0){
            asal = false;
            break;
        }
    }
    
    if(asal)
        arrayAsal.Add(sayi);
    else
        arrayAsalDegil.Add(sayi);
}

void ekranaYazdir(){
    Console.WriteLine("*****Asal olanlar*****");
    foreach (var item in arrayAsal)
    {
        Console.Write(item+" ");
    }
    Console.Write("\n");
    Console.WriteLine("*****Asal olmayanlar*****");
    foreach (var item in arrayAsalDegil)
    {
        Console.Write(item+" ");
    }
    Console.Write("\n");
}

void ortalamaVeSiralama(){
    int toplam = 0;
    int toplam2 = 0;
    
    Console.WriteLine("*****Asallarin ortalamasi ve siralanmis hali*****");
    arrayAsal.Sort();
    foreach (var item in arrayAsal)
    {
        Console.Write(item+" ");
        toplam = toplam + (int)item;
    }
    int ortalama = toplam/arrayAsal.Count;
    Console.Write("\n");
    Console.Write("Ortalama: "+ortalama);
    Console.Write("\n");
    Console.Write("Eleman sayisi: "+arrayAsal.Count);
    Console.Write("\n");

    Console.WriteLine("*****Asal olmayanlarin ortalamasi ve siralanmis hali*****");
    arrayAsal.Sort();
    foreach (var item in arrayAsalDegil)
    {
        Console.Write(item+" ");
        toplam2 = toplam2 + (int)item;
    }
    int ortalama2 = toplam2/arrayAsalDegil.Count;
    Console.Write("\n");
    Console.Write("Ortalama: "+ortalama2);
    Console.Write("\n");
    Console.Write("Eleman sayisi: "+arrayAsalDegil.Count);

}