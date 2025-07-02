// Gerekli sistem kütüphanesini içeri aktarıyoruz.
// Bu sayede temel C# işlevlerine erişebiliriz.
using System;

namespace Gun.Services
{
    // Bu interface, bir "MermiServisi"nin hangi işlevleri (metotları) sunacağını belirtir.
    // Uygulama boyunca hangi sınıf bu arayüzü implement ederse, bu davranışları yerine getirmek zorundadır.
    // Bu yapı yazılımda gevşek bağlılığı (loose coupling) ve çok biçimliliği (polymorphism) sağlar.
    public interface IMermiServisi
    {
        // Sisteme mermi yüklemek için kullanılacak metottur.
        // Parametre olarak kaç adet mermi yükleneceği verilir.
        void MermiYukle(int adet);

        // Yüklü ve hazır bir mermi varsa, ateşleme (atış) işlemi yapılır.
        void AtisYap();

        // Şu ana kadar yüklenen, atılan ve kalan mermi miktarları kullanıcıya gösterilir.
        void DurumGoster();
    }
}


/*
IMermiServisi arayüzü sayesinde, 
uygulamadaki MermiServisi sınıfı sadece bu tanımlanan metotları gerçekleştirmek zorunda. 
Bu yaklaşım bana esneklik kazandırıyor. Örneğin ileride TestMermiServisi gibi log atmayan veya 
yapay verilerle çalışan bir versiyon yazarsam kodun geri kalanını değiştirmeme gerek kalmıyor. 
Sadece IMermiServisi'nin başka bir implementasyonunu DI (Dependency Injection) ile enjekte ediyorum. 
Bu,C#’ta interface’lerin yazılım tasarımındaki en büyük avantajlarından biridir.
*/