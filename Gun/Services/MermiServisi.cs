using System;
using Gun.Entities;
namespace Gun.Services;

public class MermiServisi : IMermiServisi
    {
        private List<Mermi> mermiler = new List<Mermi>();
        private int toplamYuklenen = 0;
        private int atilanMermi = 0;

        public void MermiYukle(int adet)
        {
            for (int i = 0; i < adet; i++)
            {
                mermiler.Add(new Mermi
                {
                    HazirMi = true,
                    Kalibrasyon = Math.Round(new Random().NextDouble(), 2)
                });
            }
            toplamYuklenen += adet;
            Console.WriteLine($"{adet} mermi yüklendi.");
        }

        public void AtisYap()
        {
            if (mermiler.Any(m => m.HazirMi))
            {
                var mermi = mermiler.First(m => m.HazirMi);
                mermi.HazirMi = false;
                atilanMermi++;
                Console.WriteLine($"Atış yapıldı! Kalibrasyon: {mermi.Kalibrasyon}");
            }
            else
            {
                Console.WriteLine("Hazır mermi kalmadı!");
            }
        }

        public void DurumGoster()
        {
            int kalan = mermiler.Count(m => m.HazirMi);
            Console.WriteLine($"Toplam Yüklenen: {toplamYuklenen} | Atılan: {atilanMermi} | Kalan: {kalan}");
        }
    }
