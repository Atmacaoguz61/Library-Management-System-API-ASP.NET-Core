LibraryApi- Kütüphane Yönetim Sistemi

 	Bu Proje ASP.NET CORE WEB API ve Entity Framework Core kullanılarak yapılmış Kütüphane Yönetim Sistemidir.


Proje Özellikleri
⦁	 	Kütüphane CRUD işlemleri
⦁	 	Kitap CRUD işlemleri
⦁	 	Öğrenci CRUD işlemleri
⦁	 	Raporlama işlemleri
⦁	 	Swagger Arayüzüyle test


Kullanılan Teknolojiler
⦁	 	ASP.Net Core Web Apı
⦁	 	Entity Framework Core
⦁	 	Code First
⦁	 	SQL server
⦁	 	Swagger


Proje Yapısı
⦁	 	Controllers klasöründe controller dosyaları var kullanıcıdan gelen istekler burada karşılanır ve yapılcak olan CRUD işlemleri yönetir.
⦁	 	Models klasöründe veri modelleri yer alıyor. Her biri veri tabanında ki tabloları temsil eder.
⦁	 	Data klasöründe AppDbContext sınıfımız var EF Core veritabanı işlemlerini yapabilmesi için gereklidir.
⦁	 	Migrations klasörü EF Core Migration içeriyor. Veri tabanı yapısında oluşturduğumuz modellerde ki tabloları veritabanı için tabloya çeviren migration komutudur.
⦁	 	Program.cs Giriş dosyamızdır.Swagger arayüzü buradadır.
⦁	 	Appsetting.json içinde bağlantı bilgilerimiz yer alıyor.



Kurulum
1.	 	Projeyi Bilgisayarına indir.
2.	 	Visual Studio da aç.
3.	 	appsettings.json dosyasında ki DefaultConnection bağlantı cümlesini bilgisayarında ki SQL server bağlantına göre düzenle.
4.	 	Migrationları çalıştırıp veri tabanı oluşturmak için Tools > NuGet Package Manager > Package Manager Console kısmına öncelikle dotnet "tool install --global dotnet-ef" komutunu yaz ve çalıştır.
5.	 	Tekrar Tools > NuGet Package Manager > Package Manager Console kısmına "dotnet ef database update" komutunu yaz ve çalıştır. (SQL servera bağlanır ve tablolarını modellere göre oluşturur.)
6.	 	Projeyi çalıştır ve Swagger ile tüm endpointleri görüp test edebilirsin.


Ek Bilgi
Veritabanı işlemleri AppDbContext üzerinden yapılır. Kitap, öğrenci ve kütüphane arasında ilişkiler Entity Framework ile tanımlanmıştır. JSON gönderiminde döngü hatalarını engellemek için bazı alanlar [JsonIgnore] ile işaretlenmiştir.
Bu proje eğitim amaçlıdır.
