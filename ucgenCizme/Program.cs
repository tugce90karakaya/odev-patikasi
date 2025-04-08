Console.WriteLine("Ucgen boyutunu giriniz: ");
int boyut = Convert.ToInt32(Console.ReadLine());

for(int i = 1; i <= boyut; i++){
    for(int j = 0; j < i; j++){
        Console.Write("*");
    }
    Console.Write("\n");
}
