// Program.cs
using Gun.Services;

class Program
{
    static void Main(string[] args)
    {
        IMermiServisi mermiServisi = new MermiServisi();

        while (true)
        {
            Console.WriteLine("\n1. Mermi Yükle\n2. Atış Yap\n3. Durum Göster\n4. Çıkış");
            Console.Write("Seçim: ");
            var secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    Console.Write("Yüklenecek mermi miktarı: ");
                    if (int.TryParse(Console.ReadLine(), out int miktar))
                        mermiServisi.MermiYukle(miktar);
                    break;
                case "2":
                    mermiServisi.AtisYap();
                    break;
                case "3":
                    mermiServisi.DurumGoster();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim.");
                    break;
            }
        }
    }
}
