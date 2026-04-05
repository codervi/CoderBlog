# 🚀 CoderBlog - Social Platform for Developers
<small>*(Geliştiriciler için Sosyal Blog Platformu)*</small>

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-512bd4?style=for-the-badge&logo=dotnet)
![Entity Framework Core](https://img.shields.io/badge/EF%20Core-8.0-512bd4?style=for-the-badge&logo=dotnet)
![MSSQL](https://img.shields.io/badge/MSSQL-SQL%20Server-red?style=for-the-badge&logo=microsoft-sql-server)
![License](https://img.shields.io/badge/license-MIT-green?style=for-the-badge)

**CoderBlog** is a secure and scalable web platform built with **ASP.NET Core**, providing modern developers with social interaction and article sharing capabilities.  
<small>*(CoderBlog, modern geliştiricilere sosyal etkileşim ve makale paylaşımı sunan, ASP.NET Core ile inşa edilmiş güvenli ve ölçeklenebilir bir platformdur.)*</small>

---

## ✨ Key Features
<small>*(✨ Ana Özellikler)*</small>

* 🔐 **Secure Authentication:** Password management with BCrypt hashing and Cookie-based session control.  
  <small>*(Güvenli Kimlik Doğrulama: BCrypt hashing ile şifre yönetimi ve Cookie tabanlı oturum kontrolü.)*</small>
* 🛡️ **Modern Architecture:** Layered Architecture following Clean Architecture principles.  
  <small>*(Modern Mimari: Clean Architecture prensiplerine uygun Katmanlı Mimari yapısı.)*</small>
* 📝 **Blog Management:** Specialized article sharing and category system for developers.  
  <small>*(Blog Yönetimi: Geliştiriciler için özelleştirilmiş makale paylaşımı ve kategori sistemi.)*</small>
* 🚀 **Performance:** Optimized database queries with Entity Framework Core (LINQ).  
  <small>*(Performans: EF Core ile optimize edilmiş veritabanı sorguları.)*</small>

---

## 🛠️ Tech Stack
<small>*(🛠️ Kullanılan Teknolojiler)*</small>

* **Backend:** ASP.NET Core MVC (.NET 8)
* **ORM:** Entity Framework Core
* **Database:** Microsoft SQL Server
* **Security:** BCrypt.Net for Password Hashing
* **Frontend:** Bootstrap 5, Razor Pages, JavaScript

---

## ⚙️ Local Setup
<small>*(⚙️ Yerel Kurulum)*</small>

1. **Clone the repository:** <small>*(Projeyi klonlayın:)*</small>
   ```bash
   git clone [https://github.com/codervi/CoderBlog.git](https://github.com/codervi/CoderBlog.git)
2. **Update ConnectionStrings in `appsettings.json` to your local SQL Server.** <small>*(appsettings.json içindeki bağlantı adresini kendi yerel SQL sunucunuza göre güncelleyin.)*</small>
3. **Apply migrations via Package Manager Console:** <small>*(Migration'ları Package Manager Console üzerinden uygulayın:)*</small>
   ```bash
   Update-Database
4. **Run the project (F5).** <small>*(Projeyi çalıştırın F5.)*</small>

---

## 🤝 Contributing
<small>*(🤝 Katkıda Bulunma)*</small>

Contributions are welcome! Please check the [CONTRIBUTING.md](CONTRIBUTING.md) file first.  
<small>*(Katkılarınızı bekliyoruz! Lütfen önce CONTRIBUTING.md dosyasını inceleyin.)*</small>

## 📄 License
<small>*(📄 Lisans)*</small>

This project is licensed under the **MIT License**.  
<small>*(Bu proje MIT Lisansı ile lisanslanmıştır.)*</small>

---

**Developed with ❤️ by [Abdülsamet Yılmaz](https://github.com/codervi)**