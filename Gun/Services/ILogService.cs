// .NET’in temel sistem özelliklerini kullanmak için System namespace'ini dahil ediyoruz.
using System;

namespace Gun.Entities
{
    // ILogService bir interface'dir (arayüz).
    // Amacı, loglama işlemlerini gerçekleştirecek olan sınıflar için bir "sözleşme" tanımlamaktır.
    // Yani bu interface'i uygulayan her sınıf, mutlaka Log isimli bir metot içermek zorundadır.
    public interface ILogService
    {
        // Log mesajlarını yazmak için kullanılan metot tanımıdır.
        // Metot gövdesi burada yazılmaz; bu sadece bir şablondur (abstract davranış).
        void Log(string mesaj);
    }
}

/*
ILogService adında bir interface tanımladım çünkü loglama işlemini soyutlamak istiyorum.
 Yani mermi servisi loglamanın nasıl yapıldığını bilmemeli,
 sadece loglama yapılacağını bilmelidir.
 Bu sayede gerçek projede dosyaya,
 veritabanına ya da sadece test ortamında console'a yazdırmak gibi farklı senaryoları tek satır kod değiştirmeden uygulayabilirim.
 Bu yapı, OOP’de abstraction ve
 polymorphism prensiplerinin temel örneklerinden biridir.
*/