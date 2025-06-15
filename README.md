# E-Ticaret Web Uygulaması

Modern ve ölçeklenebilir bir e-ticaret platformu. ASP.NET MVC mimarisi kullanılarak geliştirilmiş, kullanıcı dostu arayüzü ve güçlü admin paneli ile öne çıkan bir alışveriş deneyimi sunar.

## İçindekiler
- [Proje Özeti](#proje-özeti)
- [Kullanılan Teknolojiler](#kullanılan-teknolojiler)
- [Katmanlı Mimari](#katmanlı-mimari)
- [Veritabanı Tasarımı](#veritabanı-tasarımı)
- [Kurulum](#kurulum)
- [Geliştirici Notları](#geliştirici-notları)

## Proje Özeti

Bu e-ticaret web uygulaması, kullanıcıların ürünleri listeleyebilmesi, sepete ekleyebilmesi, ödeme yapabilmesi ve siparişlerini takip edebilmesi gibi temel e-ticaret işlevlerini sağlamaktadır. Ayrıca, yöneticiler için kapsamlı bir admin paneli sunmaktadır.

## Kullanılan Teknolojiler

- **Framework**: ASP.NET Core 8.0
- **Veritabanı**: Microsoft SQL Server
- **ORM**: Entity Framework Core 8.0
- **Mimari**: N-Tier Architecture (N-Katmanlı Mimari)
- **Frontend**: HTML5, CSS3, JavaScript
- **IDE**: Visual Studio 2022
- **Versiyon Kontrolü**: Git

## Katmanlı Mimari

Proje, aşağıdaki katmanlardan oluşmaktadır:

### Core Katmanı (Eticaret.Core)
- Entity sınıfları
- Interface tanımlamaları
- Temel veri yapıları
- Ortak kullanılan yardımcı sınıflar

### Data Katmanı (Eticaret.Data)
- Entity Framework konfigürasyonları
- Veritabanı bağlantı yönetimi
- Repository implementasyonları
- Migration dosyaları

### Service Katmanı (Eticaret.Service)
- İş mantığı implementasyonları
- Servis katmanı interface'leri
- DTO (Data Transfer Object) sınıfları
- Validation işlemleri

### Web UI Katmanı (ETicaret.WebUI)
- Controller'lar
- View'lar
- Client-side scriptler
- Statik dosyalar (CSS, JS, Images)

## Veritabanı Tasarımı

### Temel Tablolar

- **AppUsers**: Kullanıcı bilgileri
- **Products**: Ürün bilgileri
- **Categories**: Kategori bilgileri
- **Brands**: Marka bilgileri
- **News**: Haber/Duyuru bilgileri
- **Contacts**: İletişim formu bilgileri
- **Sliders**: Slider bilgileri

### İlişkiler
- Products -> Categories (Many-to-One)
- Products -> Brands (Many-to-One)
- Categories -> Categories (Self-Referencing, Parent-Child)

## Kurulum

1. Projeyi klonlayın:
```bash
git clone [repository-url]
```

2. Visual Studio 2022'de solution'ı açın

3. NuGet paketlerini restore edin:
```bash
dotnet restore
```

4. Veritabanı migration'larını çalıştırın:
```bash
Add-Migration InitialCreate
Update-Database
```

5. Projeyi başlatın:
```bash
dotnet run
```

## Geliştirici Notları

### Önemli Klasör Yapıları
- `/wwwroot/Img/` - Resim dosyaları
- `/Areas/Admin/` - Admin panel dosyaları
- `/Views/` - MVC view dosyaları
- `/Controllers/` - Controller sınıfları

### Best Practices
- SOLID prensiplerine uygun geliştirme
- Clean Code yaklaşımı
- DRY (Don't Repeat Yourself) prensibi
- KISS (Keep It Simple, Stupid) prensibi

### Güvenlik Önlemleri
- Form-based authentication
- Session yönetimi
- Role-based authorization
- Client ve server-side validation

### IIS Yayınlama
1. Projeyi Release modunda derleyin
2. IIS'de yeni bir web sitesi oluşturun
3. Application Pool ayarlarını yapın
4. Web.config düzenlemelerini yapın
5. Veritabanı bağlantı ayarlarını kontrol edin

