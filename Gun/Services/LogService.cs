// Gerekli .NET sistem kütüphanesi içeri aktarılır.
// Console üzerinden çıktı almak için System namespace kullanılır.
using System;

// Mermi ve loglama işlemleriyle ilgili ortak varlıklar (entities) içe aktarılır.
// Projede "ILogService" tanımı burada yer alır (Arayüz, Interface).
using Gun.Entities;

namespace Gun.Services
{
    // LogService sınıfı, ILogService arayüzünü uygular.
    // Bu sayede, farklı loglama implementasyonları da sisteme entegre edilebilir.
    // Örn: FileLogService, DatabaseLogService vb. (Polymorphism)
    public class LogService : ILogService
    {
        // Log metodumuz dışarıdan gelen mesajı konsola yazdırır.
        // Gerçek bir log altyapısının (dosya, veritabanı, bulut logları vs.) yerine,
        // bu örnekte basitçe Console'a yazılır.
        public void Log(string mesaj)
        {
            // Log çıktısına "Emre" etiketi eklenmiştir.
            // Bu, kullanıcı bazlı log takibi yapabilmek için bir örnektir.
            Console.WriteLine($"[LOG: Emre] {mesaj}");
        }
    }
}

/*
ILogService bir interface, LogService onun gerçek uygulamasıdır. 
Projeyi geliştirirken 'bağımlılıkları azaltmak' amacıyla loglamayı soyutladım. 
Böylece test ortamında örneğin MockLogService gibi bir sahte servisle çalışabilirim. 
Bu yaklaşım, yazılımda test edilebilirliği ve sürdürülebilirliği artırır. 
Şu an için logları konsola yazıyorum ama ileride bu yapıyı hiç değiştirmeden dosyaya, 
veritabanına veya bir bulut servisine yönlendirebilirim.
*/