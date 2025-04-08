using System.Xml;

Console.WriteLine("Daire(1)");
Console.WriteLine("Ucgen(2)");
Console.WriteLine("Kare(3)");
Console.WriteLine("Dikdortgen(4)");
Console.WriteLine("*************************");
Console.WriteLine("Sekil sec:");

int secim = Convert.ToInt32(Console.ReadLine());

switch (secim)
{
    case 1:
        daire();
        break;
    case 2:
        ucgen();
        break;
    case 3:
        kare();
        break;
    case 4:
        dikdortgen();
        break;
    default:
        break;
}

void daire(){
    const float pi = 3.14f;
    Console.WriteLine("Ne hesaplamak istersiniz?");
    Console.WriteLine("Alan(1)");
    Console.WriteLine("Cevre(2)");
  

    int secim2 = Convert.ToInt32(Console.ReadLine());
    switch(secim2){
        case 1:
            Console.WriteLine("Dairenin yaricapini giriniz: ");
            int yaricap = Convert.ToInt32(Console.ReadLine());
            float alan = yaricap*yaricap*pi;
            Console.WriteLine("Dairenin yaricapi: "+alan);
            break;
        case 2:
            Console.WriteLine("Dairenin yaricapini giriniz: ");
            int yaricap2 = Convert.ToInt32(Console.ReadLine());
            float cevre = 2*pi*yaricap2;
            Console.WriteLine("Dairenin cevresi: "+cevre);
            break;

        default:
            Console.WriteLine("Gecerli islem yap");
            break;
    }


}
void ucgen(){
    Console.WriteLine("Ne hesaplamak istersiniz?");
    Console.WriteLine("Alan(1)");
    Console.WriteLine("Cevre(2)");
    

    int secim = Convert.ToInt32(Console.ReadLine());

    switch(secim){
        case 1:
            Console.WriteLine("Ucgenin tabanini girin: ");
            int taban = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ucgenin yuksekligini girin: ");
            int yukseklik = Convert.ToInt32(Console.ReadLine());
            float alan = (taban*yukseklik)/2;
            Console.WriteLine("Ucgenin alani: "+alan);
            break;
        case 2:
             int[] dizi = new int[3];
             int toplam = 0;
             for(int i = 0; i < 3; i++){
                Console.WriteLine("Ucgenin kenarini girin: ");
                int kenar = Convert.ToInt32(Console.ReadLine());
                dizi[i] = kenar;
             }
             for(int i = 0; i < 3; i++){
                toplam = toplam + dizi[i];
             }
             int cevre = toplam;
             Console.WriteLine("Ucgenin cevresi: "+cevre);
             break;
        
        default:
            Console.WriteLine("Gecerli bir islem yap");
            break;
    }

    
}
void kare(){
    Console.WriteLine("Ne hesaplamak istersiniz?");
    Console.WriteLine("Alan(1)");
    Console.WriteLine("Cevre(2)");
   

    int secim = Convert.ToInt32(Console.ReadLine());

    switch(secim){
        case 1:
            Console.WriteLine("Karenin kenarini girin: ");
            int kenar = Convert.ToInt32(Console.ReadLine());
            int alan = kenar*kenar;
            Console.WriteLine("Karenin alani: "+alan);
            break;
        case 2:
            Console.WriteLine("Karenin kenarini girin: ");
            int kenar2 = Convert.ToInt32(Console.ReadLine());
            int cevre = 4*kenar2;
            Console.WriteLine("Karenin cevresi: "+cevre);
            break;

        default:
            Console.WriteLine("Gecerli bir islem yap");
            break;
    }

}
void dikdortgen(){
    Console.WriteLine("Ne hesaplamak istersiniz?");
    Console.WriteLine("Alan(1)");
    Console.WriteLine("Cevre(2)");
   

    int secim = Convert.ToInt32(Console.ReadLine());

    switch(secim){
        case 1:
            Console.WriteLine("Dikdortgenin uzun kenarini girin: ");
            int uzunKenar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dikdortgenin kisa kenarini girin: ");
            int kisaKenar = Convert.ToInt32(Console.ReadLine());
            int alan = uzunKenar*kisaKenar;
            Console.WriteLine("Karenin alani: "+alan);
            break;
        case 2:
            Console.WriteLine("Dikdortgenin uzun kenarini girin: ");
            int uzunKenar2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Dikdortgenin kisa kenarini girin: ");
            int kisaKenar2 = Convert.ToInt32(Console.ReadLine());
            int cevre = 2*uzunKenar2 + 2*kisaKenar2;
            Console.WriteLine("Karenin cevresi: "+cevre);
            break;

        default:
            Console.WriteLine("Gecerli bir islem yap");
            break;
    }
}