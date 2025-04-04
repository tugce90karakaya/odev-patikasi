using System.Collections;

ArrayList dizi = new ArrayList();
ArrayList sesliHarf = new ArrayList();

Console.WriteLine("Bir cumle giriniz: ");
string kelime = Console.ReadLine();
dizi.AddRange(kelime.Split(" "));

foreach (string item in dizi)
{
    for(int i = 0; i < item.Length; i++){
        if(item[i] == 'a'|| item[i] == 'e' || item[i] == 'i' ||item[i] == 'o'||item[i] == 'u'){
            sesliHarf.Add(item[i]);
        }
    }
}
Console.WriteLine("***sesli harf dizisi***");
sesliHarf.Sort();
foreach (var item in sesliHarf)
{
    Console.WriteLine(item);
}




