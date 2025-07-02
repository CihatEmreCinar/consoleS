using Gun.Entities;

namespace Gun.Services
{
    // Test ortamında gerçek işlemleri yapmayan sahte servis
    public class FakeMermiServisi : IMermiServisi
    {
        private readonly ILogService _log;

        public FakeMermiServisi(ILogService log)
        {
            _log = log;
        }

        public void MermiYukle(int adet)
        {
            _log.Log($"[TEST] {adet} mermi yükleme simülasyonu yapıldı.");
        }

        public void AtisYap()
        {
            _log.Log("[TEST] Atış yapıldı (gerçek mermi kullanılmadı).");
        }

        public void DurumGoster()
        {
            _log.Log("[TEST] Durum gösterildi: Simülasyon verisi.");
        }
    }
}
