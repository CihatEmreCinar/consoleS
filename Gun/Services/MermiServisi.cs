// Gerekli sistem ve varlık (entity) sınıflarını içeri aktarıyoruz.
// "Gun.Entities" içinde Mermi nesnesi tanımlıdır.
// "ILogService", dış dünyaya bağımlılığı soyutlamak için kullanılır (Dependency Injection).
using System;
using Gun.Entities;

namespace Gun.Services
{
    // MermiServisi, IMermiServisi arayüzünü uygular.
    // Böylece bu sınıf test edilebilir, değiştirilebilir, genişletilebilir hale gelir (Polymorphism, Interface Segregation).
    public class MermiServisi : IMermiServisi
    {
        // Bağımlılıkları dışarıdan almak için constructor injection kullanılır.
        // Bu sayede servis loosely coupled (gevşek bağlı) olur.
        private readonly ILogService _log;

        // Uygulama içindeki mermileri tutacak liste. Her mermi ayrı bir nesnedir.
        // Encapsulation ile sadece bu sınıf erişebilir.
        private List<Mermi> mermiler = new List<Mermi>();

        // Toplam yüklenen ve atılan mermi sayısı tutulur. Bu sayılar loglanır.
        private int toplamYuklenen = 0;
        private int atilanMermi = 0;

        // Yapıcı metod (Constructor) ile ILogService enjekte edilir (Dependency Injection).
        // Bu sayede loglama mekanizması bu sınıfa gömülü değildir. 
        // İstenirse farklı log servisleri ile değiştirilebilir (Open/Closed Principle).
        public MermiServisi(ILogService log)
        {
            _log = log;
        }

        // Mermi yükleme işlemini gerçekleştirir.
        // Her mermi rastgele bir kalibrasyon değeriyle sisteme eklenir (Simülasyon gerçekçiliği).
        public void MermiYukle(int adet)
        {
            for (int i = 0; i < adet; i++)
            {
                mermiler.Add(new Mermi
                {
                    HazirMi = true, // Mermi sisteme yüklendiğinde hazır olarak işaretlenir.
                    Kalibrasyon = Math.Round(new Random().NextDouble(), 2) // 0.00 ile 1.00 arası rastgele hassasiyet değeri atanır.
                });
            }

            // Toplam yüklenen mermi sayısı güncellenir.
            toplamYuklenen += adet;

            // İşlem başarıyla tamamlandıysa log mesajı yazılır.
            _log.Log($"{adet} mermi yüklendi.");
        }

        // Mermi ateşleme işlemini gerçekleştirir.
        public void AtisYap()
        {
            // Eğer hazır mermi varsa atış yapılır.
            if (mermiler.Any(m => m.HazirMi))
            {
                // İlk hazır mermi alınır.
                var mermi = mermiler.First(m => m.HazirMi);

                // Mermi artık hazır değildir çünkü atış yapılmıştır.
                mermi.HazirMi = false;

                // Atılan mermi sayısı artırılır.
                atilanMermi++;

                // Kalibrasyon değeri ile birlikte log yazılır (gerçekçi simülasyon takibi).
                _log.Log($"Atış yapıldı! Kalibrasyon: {mermi.Kalibrasyon}");
            }
            else
            {
                // Eğer hiç hazır mermi yoksa, kullanıcı bilgilendirilir.
                _log.Log("Hazır mermi kalmadı!");
            }
        }

        // Sistemdeki mermi durumunu kullanıcıya gösterir.
        public void DurumGoster()
        {
            // Kalan mermi sayısı hesaplanır.
            int kalan = mermiler.Count(m => m.HazirMi);

            // Tüm veriler log olarak gösterilir.
            // Bu log ile kullanıcı sistemin mevcut durumunu görebilir.
            _log.Log($"Toplam Yüklenen: {toplamYuklenen} | Atılan: {atilanMermi} | Kalan: {kalan}");
        }
    }
}

/*
Bu sınıfı tasarlarken Interface ve Dependency Injection prensiplerini uyguladım. 
ILogService arayüzü üzerinden loglamayı dışarıya taşıdım, böylece test veya üretim ortamında farklı loglama stratejileriyle değiştirebilirim. 
Mermileri liste olarak tutuyorum çünkü birden fazla nesneyle çalışmak istiyorum. 
Kalibrasyon gibi değerlerle her mermiyi özgün hale getirdim, bu da gerçekçi bir simülasyon ortamı sağlar. 
Bu yapı sayesinde sistemi hem genişletmek hem de test etmek çok kolay.
*/