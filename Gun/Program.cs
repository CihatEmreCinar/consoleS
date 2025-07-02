// Gerekli sınıflar ve arayüzler projeden içe aktarılır.
// Gun.Entities: Mermi, BaseEntity, ILogService gibi entity ve arayüzler
// Gun.Services: MermiServisi ve LogServisi gibi iş katmanları (Business Layer)
using Gun.Entities;
using Gun.Services;

// Microsoft'un sağladığı Dependency Injection (DI) araçları içe aktarılıyor.
// Bu sayede servisleri manuel yaratmak yerine .NET'e bağımlılıkları yönetmesi söyleniyor.
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        //  DI yapılandırması (Dependency Injection Container)
        // ServiceCollection içine servisler tanımlanıyor.
        // ILogService => LogService olarak eşleniyor (Singleton: uygulama boyunca bir kez yaratılır)
        // IMermiServisi => MermiServisi olarak atanıyor.
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ILogService, LogService>()
            .AddSingleton<IMermiServisi, MermiServisi>() //Fake mermi servisi burada implement edip test sağlayabiliriz..AddSingleton<IMermiServisi, FakeMermiServisi>()
            .BuildServiceProvider();

        // Servisler dışarıdan alınarak kullanıma hazır hale getirilir.
        // Burada constructor değil, service provider üzerinden alınmış oldu.
        var log = serviceProvider.GetService<ILogService>();
        var mermiServisi = serviceProvider.GetService<IMermiServisi>();

        // Log atılır: sistem başladığında kullanıcıyı bilgilendirmek için
        log?.Log("MermiServisi başlatılıyor...");
        log?.Log("Servis başarıyla başlatıldı. Kullanıcı: Emre\n");

        // Kullanıcıdan sürekli giriş alınacak bir menü ekranı başlatılıyor.
        while (true)
        {
            Console.WriteLine("\n1. Mermi Yükle\n2. Atış Yap\n3. Durum Göster\n4. Çıkış");
            Console.Write("Seçim: ");
            var secim = Console.ReadLine();

            // Kullanıcının seçimlerine göre sistem davranış değiştiriyor (runtime'da!)
            switch (secim)
            {
                case "1":
                    Console.Write("Yüklenecek mermi miktarı: ");
                    if (int.TryParse(Console.ReadLine(), out int miktar))
                        mermiServisi?.MermiYukle(miktar);
                    break;

                case "2":
                    mermiServisi?.AtisYap();
                    break;

                case "3":
                    mermiServisi?.DurumGoster();
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


/*
Program.cs dosyam uygulamanın giriş noktası.
 Burada Microsoft.Extensions.
DependencyInjection kullandım çünkü servisleri manuel new'lemek yerine gevşek bağlılık (loose coupling) prensibini uygulamak istedim.
 Singleton pattern ile her servisten yalnızca bir tane oluşturuluyor,
 bu da performans ve test edilebilirlik açısından faydalı.
 Kullanıcıya bir menü sundum;
 bu menü üzerinden arka plandaki servislerle (iş mantığıyla) etkileşim kurabiliyor. 
Tüm loglama işlemlerini ILogService ile soyutladım. 
Bu sayede loglama yapısını değiştirmek istersem tek satır kod değiştirmem yeterli. 
Bu yapı, OOP prensipleri olan Encapsulation, Abstraction,
 Polymorphism ve Dependency Injection’ı bir arada barındırıyor
*/