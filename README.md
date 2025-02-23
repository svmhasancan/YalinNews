# Yalin News Backend API

Bu proje, haber portalı için geliştirilmiş bir .NET Core Web API projesidir. SOLID prensiplerine uygun, kurumsal mimari yapısında geliştirilmiştir.

## 🚀 Özellikler

- Haber ekleme, silme, güncelleme ve listeleme
- Kategori yönetimi
- Yazar yönetimi
- JWT tabanlı kimlik doğrulama ve yetkilendirme
- Rol bazlı erişim kontrolü
- Aspect Oriented Programming (AOP) yapısı
- Generic Repository Pattern
- Cross-Cutting Concerns
- IoC Container (Autofac)

## 🛠️ Kullanılan Teknolojiler

- **.NET 8.0**
- **Entity Framework Core 8.0**
- **Autofac** (IoC Container)
- **JWT (JSON Web Token)**
- **AutoMapper**
- **MS SQL Server**
- **Swagger**

## 📦 Katmanlar

- **Core**: Projenin çekirdek katmanı, tüm projelerde kullanılabilecek yapıları içerir
- **Entities**: Veritabanı nesneleri ve DTO'lar
- **DataAccess**: Veritabanı işlemleri ve Entity Framework yapılandırması
- **Business**: İş kuralları ve validasyon işlemleri
- **WebAPI**: REST API endpoints ve controller'lar

## 🔧 Kurulum

1. Projeyi klonlayın
bash
git clone https://github.com/svmhasancan/YalinNews.git

2. Veritabanını oluşturun
bash
update-database


3. Projeyi çalıştırın
bash
dotnet run


## 📝 API Endpoints

### Auth
- POST `/api/auth/register`: Yeni kullanıcı kaydı
- POST `/api/auth/login`: Kullanıcı girişi

### News
- GET `/api/news`: Tüm haberleri listele
- GET `/api/news/{id}`: ID'ye göre haber getir
- POST `/api/news`: Yeni haber ekle (Editor, Admin)
- PUT `/api/news`: Haber güncelle (Editor, Admin)
- DELETE `/api/news/{id}`: Haber sil (Admin)

### Categories
- GET `/api/categories`: Tüm kategorileri listele
- POST `/api/categories`: Yeni kategori ekle

### Authors
- GET `/api/authors`: Tüm yazarları listele
- POST `/api/authors`: Yeni yazar ekle

## 🔐 Güvenlik

- JWT tabanlı kimlik doğrulama
- Role bazlı yetkilendirme (Admin, Editor, User)
- Password hashing ve salting
- Secure token yapısı

## 📚 Kullanılan NuGet Paketleri ve Sürümleri

- Autofac 7.1.0
- Autofac.Extensions.DependencyInjection 8.0.0
- Autofac.Extras.DynamicProxy 7.1.0
- Microsoft.AspNetCore.Authentication.JwtBearer 8.0.0
- Microsoft.EntityFrameworkCore.SqlServer 8.0.0
- Microsoft.EntityFrameworkCore.Tools 8.0.0

## 🤝 Katkıda Bulunma

1. Fork edin
2. Feature branch oluşturun (`git checkout -b feature/amazing-feature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some amazing feature'`)
4. Branch'inize push edin (`git push origin feature/amazing-feature`)
5. Pull Request oluşturun


## 📞 İletişim

Email: shasancan0@gmail.com
