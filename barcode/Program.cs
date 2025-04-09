using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using BarcodeLib;
using ZXing;

class Program
{
    static void Main(string[] args)
    {
        string barcodeText = "1234567890";
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "barcode.png");

        Console.WriteLine("=== BARCODE GENERATOR & READER ===\n");

        // 1. Barcode Oluştur
        Console.WriteLine("Barcode oluşturuluyor...");
        GenerateBarcode(barcodeText, filePath);
        Console.WriteLine($"Barcode kaydedildi: {filePath}\n");

        // 2. Barcode Oku
        Console.WriteLine("Barcode okunuyor...");
        string result = ReadBarcode(filePath);
        Console.WriteLine("Okunan Değer: " + result);
    }

    static void GenerateBarcode(string text, string path)
    {
        Barcode barcode = new Barcode();
        Image img = barcode.Encode(TYPE.CODE128, text, Color.Black, Color.White, 300, 150);

        img.Save(path, ImageFormat.Png);
    }

    static string ReadBarcode(string path)
    {
        var reader = new BarcodeReader();

        using (var bitmap = (Bitmap)Bitmap.FromFile(path))
        {
            var result = reader.Decode(bitmap);
            return result?.Text ?? "Barcode çözülemedi.";
        }
    }
}
