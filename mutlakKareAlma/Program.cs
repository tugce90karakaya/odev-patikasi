Console.WriteLine("Kac sayi girilecek: ");
int uzunluk = Convert.ToInt32(Console.ReadLine());
int[] dizi = new int[uzunluk];
int farkToplami = 0, mutlakKareToplami = 0, mutlakKare = 0;

for(int i = 0; i < uzunluk; i++){
    Console.WriteLine("Sayi gir: ");
    dizi[i] = Convert.ToInt32(Console.ReadLine());
}
for(int i = 0; i < uzunluk; i++){
    if(dizi[i] < 67){
        farkToplami = farkToplami + (67 - dizi[i]);
    }
    else if(dizi[i] > 67){
        mutlakKare = dizi[i] - 67;
        mutlakKareToplami = mutlakKareToplami + (mutlakKare*mutlakKare);

        
    }
}
Console.Write(farkToplami+" "+mutlakKareToplami);

